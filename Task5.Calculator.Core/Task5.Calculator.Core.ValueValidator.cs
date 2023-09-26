using System.Globalization;
using System.Text.RegularExpressions;
using Task5.Calculator.Core.Interfaces;

namespace Task5.Calculator.Core
{
    public enum Errors
    {
        WrongInput,
        DivideByZero,
        AllCorrect
    }
    public class ValueValidator : IValueValidator
    {
        private readonly CultureInfo _culture;
        private readonly NumberStyles _numberStyles;
        private const string _validCharactersPattern = @"^[()+\-\*/.\d\s]+$";
        private const string _repeatingSymbolsPattern = "[+\\-*./]{2}";
        public ValueValidator()
        {
            _culture = CultureInfo.InvariantCulture;
            _numberStyles = NumberStyles.Float;
        }

        public bool IsNumber(string value)
        {
            return double.TryParse(value, _numberStyles, _culture, out _);
        }

        public bool IsOperator(string value)
        {
            return value == "+" || value == "-" || value == "*" || value == "/";
        }
       
        public Errors GetErrorStatement(string value)
        {
            if (!Regex.IsMatch(value, _validCharactersPattern))
            {
                return Errors.WrongInput;
            }

            if (Regex.IsMatch(value, _repeatingSymbolsPattern))
            {
                return Errors.WrongInput;
            }
           
            if (!IsBracketsCorrect(value))
            {
                return Errors.WrongInput;
            }

            if (!char.IsDigit(value[0]) && value[0] != '(' && value[0] != '-')
            {
                return Errors.WrongInput;
            }

            return Errors.AllCorrect;
        }

        private bool IsBracketsCorrect(string expression)
        {
            Stack<char> stack = new Stack<char>();
            foreach (char c in expression)
            {
                if (c == '(')
                {
                    stack.Push(c);
                }
                else if (c == ')')
                {
                    if (stack.Count == 0 || stack.Peek() != '(')
                    {
                        return false;
                    }

                    stack.Pop();
                }
            }

            return stack.Count == 0 && !IsAnyEmptyBrackets(expression);
        }

        private bool IsAnyEmptyBrackets(string expression)
        {
            return expression.Contains("()");
        }

    }
}
