using System.Diagnostics.CodeAnalysis;
using Task5.Calculator.Core.Interfaces;

namespace Task5.Calculator.Core
{
    [ExcludeFromCodeCoverage]
    internal class StartPoint : IStartPoint
    {
        private readonly IUserInput _userInput;
        private readonly IStringProcessor _stringProcessor;
        private readonly IFileProcessor _fileProcessor;

        public StartPoint(IUserInput userInput, IStringProcessor stringProcessor, IFileProcessor fileProcessor)
        {
            _userInput = userInput;
            _stringProcessor = stringProcessor;
            _fileProcessor = fileProcessor;
        }

        public void Run()
        {
            var input = _userInput.GetUserInput();
            input = input.Replace(" ", string.Empty);
            if (File.Exists(input.Trim('"')))
            {
                _fileProcessor.FileProcessor(input);
            }
            else
            {
                _stringProcessor.StringProcessor(input);
            }

        }
    }
}
