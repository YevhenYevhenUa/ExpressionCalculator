using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.Calculator.Core;
using Task5.Calculator.Core.Interfaces;

namespace Task5.Calculator.Tests
{
    [TestClass]
    public class ProcessorsTester
    {
        private readonly UserInterface _userInterface;
        public ProcessorsTester()
        {
            _userInterface = new UserInterface();
        }
        [TestMethod]
        public void Processors_StringProccessor_ShouldReturnCorrectStringResult()
        {
            //Arrange
            string testExpression = "2+15/3+4*2";
            double expectResult = 15d;
            var _calculator = new Mock<ICalculator>();
            var _valueValidator = new Mock<IValueValidator>();
            _calculator.Setup(s => s.GetResult(testExpression)).Returns("15");
            _valueValidator.Setup(s => s.GetErrorStatement(testExpression)).Returns(Errors.AllCorrect);
            IStringProcessor processors = new Processors(_valueValidator.Object, _calculator.Object, _userInterface);
            //Act
            using StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            processors.StringProcessor(testExpression);
            string actualResult = stringWriter.ToString().Trim();
            double parsedActualRes = double.Parse(actualResult);
            //Assert
            Assert.AreEqual(expectResult, parsedActualRes);
        }
        [TestMethod]
        public void Processors_StringProccessor_ShouldReturnErrorIfDivideByZero()
        {
            //Arrange
            string expectResult = "Exception. Divide by zero.";
            string testExpression = "5/0";
            var _calculator = new Mock<ICalculator>();
            var _valueValidator = new Mock<IValueValidator>();
            _calculator.Setup(s => s.GetResult(testExpression)).Returns("Exception. Divide by zero.");
            _valueValidator.Setup(s => s.GetErrorStatement(testExpression)).Returns(Errors.DivideByZero);
            IStringProcessor processors = new Processors(_valueValidator.Object, _calculator.Object, _userInterface);
            //Act
            using StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            processors.StringProcessor(testExpression);
            string actualResult = stringWriter.ToString().Trim();
            //Assert
            Assert.AreEqual(expectResult, actualResult);
        }
        [TestMethod]
        public void Processors_StringProccessor_ShouldReturnErrorIfIncorrectInput()
        {
            //Arrange
            string expectResult = "Exception. Wrong input.";
            string testExpression = "1+x+4";
            var _calculator = new Mock<ICalculator>();
            var _valueValidator = new Mock<IValueValidator>();
            _valueValidator.Setup(s => s.GetErrorStatement(testExpression)).Returns(Errors.WrongInput);
            IStringProcessor processors = new Processors(_valueValidator.Object, _calculator.Object, _userInterface);
            //Act
            using StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            processors.StringProcessor(testExpression);
            string actualResult = stringWriter.ToString().Trim();
            //Assert
            Assert.AreEqual(expectResult, actualResult);
        }
        
    }
}
