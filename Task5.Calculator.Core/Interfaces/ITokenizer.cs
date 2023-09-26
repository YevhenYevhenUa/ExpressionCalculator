namespace Task5.Calculator.Core.Interfaces
{
    public interface ITokenizer
    {
        List<string>? GetTokens(string expression);
    }
}