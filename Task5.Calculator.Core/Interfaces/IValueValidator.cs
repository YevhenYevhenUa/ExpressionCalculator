namespace Task5.Calculator.Core.Interfaces
{
    public interface IValueValidator
    {
        bool IsNumber(string value);
        bool IsOperator(string value);
        Errors GetErrorStatement(string value);

    }
}