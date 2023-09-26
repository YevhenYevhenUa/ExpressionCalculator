using System.Text;
using Task5.Calculator.Core.Interfaces;

namespace Task5.Calculator.Core
{
    public class Processors : IFileProcessor, IStringProcessor
    {
        private readonly IValueValidator _valueValidator;
        private readonly ICalculator _calculator;
        private readonly IUserInterface _userInterface;
        private const string _newFileName = "result.txt";

        public Processors(IValueValidator valueValidator, ICalculator calculator, IUserInterface userInterface)
        {
            _valueValidator = valueValidator;
            _calculator = calculator;
            _userInterface = userInterface;
        }

        public void StringProcessor(string expression)
        {
            var statement = _valueValidator.GetErrorStatement(expression);
            string validation = _userInterface.GetMessage(statement);
            string result;
            if (statement == Errors.AllCorrect)
            {
                result = _calculator.GetResult(expression);
            }
            else
            {
                result = validation;
            }

            _userInterface.ShowResult(result);
        }

        public void FileProcessor(string filePath)
        {
            using StreamReader reader = new(filePath.Trim('"'));
            var path = Path.Combine(Directory.GetCurrentDirectory(), _newFileName);
            using FileStream file = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            string? line;
            string result;
            while ((line = reader.ReadLine()) is not null)
            {
                var statement = _valueValidator.GetErrorStatement(line);
                string validation = _userInterface.GetMessage(statement);
                if (statement == Errors.AllCorrect)
                {
                    result = _calculator.GetResult(line);
                }
                else
                {
                    result = validation;
                }
                string tempS = string.Format("{0} = {1}\n", line, result);
                byte[] input = Encoding.Default.GetBytes(tempS);
                file.Write(input, 0, input.Length);
            }
        }

    }
}
