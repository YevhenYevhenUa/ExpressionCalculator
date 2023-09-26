using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.Calculator.Core;

namespace Task5.Calculator.Tests
{
    [TestClass]
    public class UserInterfaceTester
    {
        private readonly UserInterface _userInterface;
        public UserInterfaceTester()
        {
            _userInterface = new UserInterface();
        }
        [TestMethod]
        [DataRow("2+2-2+2")]
        [DataRow("D:\\File.txt\\")]
        public void UserInterface_GetUserInput_ShouldReturnCorrectUserInput(string input)
        {
            //Arrange
            //Act
            using StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);
            string actualResult = _userInterface.GetUserInput();
            //Assert
            Assert.AreEqual(input, actualResult);
        }

        [TestMethod]
        [DataRow(Errors.DivideByZero, "Exception. Divide by zero.")]
        [DataRow(Errors.WrongInput, "Exception. Wrong input.")]
        [DataRow(Errors.AllCorrect, "")]
        public void UserInterface_GetUserInput_ShouldReturnExceptionMessageDependingOnInputValue(Errors errors, string expectString)
        {
            //Arrange
            //Act
            string actrualRes = _userInterface.GetMessage(errors);
            //Assert
            Assert.AreEqual(expectString, actrualRes);
        }

    }
}
