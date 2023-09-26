using Moq;
using System;
using System.ComponentModel;
using Task5.Calculator.Core;
using Task5.Calculator.Core.Interfaces;

namespace Task5.Calculator.Tests
{
    [TestClass]
    public class ConverterTester
    {
        [TestMethod]
        public void Converter_GetRPNExpression_ShouldReturnCorrectList()
        {
            //Assert
            ValueValidator validator = new ValueValidator();
            RPNConverter rPNConverter = new(validator);
            List<string> testList = new List<string>() { "2", "+", "15", "/", "3", "+", "4", "*", "2"};
            List<string> expectList = new List<string>() { "2", "15", "3", "/", "+", "4", "2", "*", "+" };
            //Act
            List<string> actualList = rPNConverter.GetRPNExpression(testList);
            //Assert
            CollectionAssert.AreEquivalent(expectList, actualList);
        }

    }
}