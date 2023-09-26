namespace Task5.Calculator.Core.Interfaces
{
    public interface IUserInterface
    {
        void ShowResult(string message);
        string GetMessage(Errors errors);
    }
}