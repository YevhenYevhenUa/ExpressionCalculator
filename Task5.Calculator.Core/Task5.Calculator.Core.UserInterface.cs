using Task5.Calculator.Core.Interfaces;

namespace Task5.Calculator.Core
{
    public class UserInterface : IUserInterface, IUserInput
    {
        public string GetUserInput()
        {
            Console.WriteLine("Enter mathematical expression or file adress: ");
            var userInput = Console.ReadLine();
            return userInput;
        }

        public string GetMessage(Errors errors)
        {
            switch (errors) 
            {
                case Errors.WrongInput: return "Exception. Wrong input.";
                case Errors.DivideByZero: return "Exception. Divide by zero.";
                case Errors.AllCorrect: return string.Empty;
                    default: throw new ArgumentException();
            } 
        }
        
        public void ShowResult(string message)
        {
            Console.WriteLine(message);
        }

    }
}
