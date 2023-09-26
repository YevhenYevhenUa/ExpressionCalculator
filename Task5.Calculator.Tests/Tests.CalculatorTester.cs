using Moq;
using Task5.Calculator.Core;
using Task5.Calculator.Core.Interfaces;

namespace Task5.Calculator.Tests
{
    [TestClass]
    public class CalculatorTester
    {
        private readonly ValueValidator _valueValidator;
        private readonly Mock<ITokenizer> _tokenizer;
        private readonly Mock<IConverter> _converter;
        private readonly Mock<IUserInterface> _userInterface;
        public CalculatorTester()
        {
            _valueValidator = new ValueValidator();
            _converter = new Mock<IConverter>();
            _tokenizer = new Mock<ITokenizer>();
            _userInterface = new Mock<IUserInterface>();
        }

        [TestMethod]
        public void Calculator_EvaluateRPN_ShouldCalculateExpressionAndReturnResult()
        {
            //Arrange
            CalculatorClass calculator = new(_valueValidator, _tokenizer.Object, _converter.Object, _userInterface.Object);
            List<string> testList = new List<string>() { "2", "15", "3", "/", "+", "4", "2", "*", "+" };
            double expectResult = 15d;
            //Act
            string actualResult = calculator.EvaluateRPN(testList);
            double parsedActualRes = double.Parse(actualResult);
            //Assert
            Assert.AreEqual(expectResult, parsedActualRes);
        }
        [TestMethod]
        [DataRow("2+15/3+4*2", 15d)]
        [DataRow("1+2*(3+2)", 11d)]
        public void Calcuclator_GetResult_ShouldReturnResultOfProcessingStringExpression(string expression, double expectResult)
        {
            //Arrange
            var tokenizer = new Tokenizer(_valueValidator);
            var converter = new RPNConverter(_valueValidator);
            CalculatorClass calculator = new CalculatorClass(_valueValidator, tokenizer, converter, _userInterface.Object);
            //Act
            string actualResult = calculator.GetResult(expression);
            double parsedActualRes = double.Parse(actualResult);
            //Assert
            Assert.AreEqual(expectResult, parsedActualRes);
        }
    }
}
