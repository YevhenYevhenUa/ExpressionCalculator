using Task5.Calculator.Core.Interfaces;

namespace Task5.Calculator.Core
{
    public class RPNConverter : IConverter
    {
        private readonly IValueValidator _valueValidator;
        private readonly Dictionary<string, int> _operatorOrder = new Dictionary<string, int>()
            {
                {"+", 1 },
                {"-", 1 },
                {"*", 2 },
                {"/", 2 }
            };

        public RPNConverter(IValueValidator valueValidator)
        {
            _valueValidator = valueValidator;
        }

        public List<string> GetRPNExpression(List<string> tokens)
        {
            List<string> rpnExpression = new List<string>();
            Stack<string> operatorStack = new Stack<string>();

            foreach (string token in tokens)
            {
                if (_valueValidator.IsNumber(token))
                {
                    rpnExpression.Add(token);
                }
                else if (_valueValidator.IsOperator(token))
                {
                    while (operatorStack.Count > 0 && _valueValidator.IsOperator(operatorStack.Peek()) && _operatorOrder[token] <= _operatorOrder[operatorStack.Peek()])
                    {
                        rpnExpression.Add(operatorStack.Pop());
                    }

                    operatorStack.Push(token);
                }
                else if (token == "(")
                {
                    operatorStack.Push(token);
                }
                else if (token == ")")
                {
                    while (operatorStack.Count > 0 && operatorStack.Peek() != "(")
                    {
                        rpnExpression.Add(operatorStack.Pop());
                    }

                    if (operatorStack.Count > 0 && operatorStack.Peek() == "(")
                    {
                        operatorStack.Pop();
                    }
                }
            }

            while (operatorStack.Count > 0)
            {
                rpnExpression.Add(operatorStack.Pop());
            }

            return rpnExpression;
        }

    }
}
