using System.Text.RegularExpressions;
using Task5.Calculator.Core.Interfaces;

namespace Task5.Calculator.Core
{
    public class Tokenizer : ITokenizer
    {
        private readonly IValueValidator _valueValidator;
        private const string _pattern = @"(-?\d+(\.\d+)?|\D)";
        public Tokenizer(IValueValidator valueValidator)
        {

            _valueValidator = valueValidator;
        }

        public List<string> GetTokens(string expression)
        {
            MatchCollection matches = Regex.Matches(expression.Replace(" ", string.Empty), _pattern);
            List<string> result = new List<string>();

            for (int i = 0; i < matches.Count; i++)
            {
                if (_valueValidator.IsNumber(matches[i].Value) && i == 0 && matches[i].Value.Contains("-"))
                {
                    result.Add("0");
                }
                else if (matches[i].Value == "(" && matches[i + 1].Value.Contains("-"))
                {
                    result.Add("(");
                    result.Add("0");
                    continue;
                }


                if (matches[i].Value.Contains('-'))
                {
                    result.Add("+");
                    result.Add(matches[i].Value);
                }
                else
                {
                    result.Add(matches[i].Value);
                }
            }

            return result;
        }

    }
}
