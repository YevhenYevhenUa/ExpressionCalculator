using System.Globalization;
using Task5.Calculator.Core.Interfaces;

namespace Task5.Calculator.Core
{
    public class CalculatorClass : ICalculator
    {
        private readonly IValueValidator _valueValidator;
        private readonly ITokenizer _tokenizer;
        private readonly IConverter _converter;
        private readonly IUserInterface _userInterface;
        private readonly CultureInfo _culture;
        private readonly NumberStyles _numberStyle;

        public CalculatorClass(IValueValidator valueValidator, ITokenizer tokenizer, IConverter converter, IUserInterface userInterface)
        {
            _valueValidator = valueValidator;
            _tokenizer = tokenizer;
            _converter = converter;
            _userInterface = userInterface;
            _culture = CultureInfo.InvariantCulture;
            _numberStyle = NumberStyles.Float;
        }

        public string GetResult(string expression)
        {
            List<string> tokenList = _tokenizer.GetTokens(expression);
            List<string> rpnList = _converter.GetRPNExpression(tokenList);
            string result = EvaluateRPN(rpnList);
            return result;
        }

        public string EvaluateRPN(List<string> rpnExpression)
        {
            Stack<double> operandStack = new Stack<double>();
            foreach (var item in rpnExpression)
            {
                if (_valueValidator.IsNumber(item))
                {
                    operandStack.Push(double.Parse(item, _numberStyle, _culture));
                }
                else if (_valueValidator.IsOperator(item) && operandStack.Count != 1)
                {
                    double oper1 = operandStack.Pop();
                    double oper2 = operandStack.Pop();
                    double result;
                    if (!(item == "/" && oper1 == 0))
                    {
                       result = ApplyOperator(oper1, oper2, item);
                    }
                    else
                    {
                        return _userInterface.GetMessage(Errors.DivideByZero);
                    }
                    operandStack.Push(result);
                }
                else if (_valueValidator.IsOperator(item) && operandStack.Count == 1)
                {
                    return _userInterface.GetMessage(Errors.WrongInput);
                }
            }
            return operandStack.Pop().ToString("f2");
        }

        private double ApplyOperator(double operand1, double operand2, string @operator)
        {
            switch (@operator)
            {
                case "+": return operand1 + operand2;
                case "-": return operand2 - operand1;
                case "*": return operand1 * operand2;
                case "/": return operand2 / operand1;
                default:
                    throw new ArgumentException("Something went wrong!");
            }

        }
    }
}
