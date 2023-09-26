namespace Task5.Calculator.Core.Interfaces
{
    public interface ICalculator
    {
        string EvaluateRPN(List<string> rpnExpression);
        string GetResult(string expression);

    }
}