namespace Task5.Calculator.Core.Interfaces
{
    public interface IConverter
    {
        List<string> GetRPNExpression(List<string> tokens);
    }
}