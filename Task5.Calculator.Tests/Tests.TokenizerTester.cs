using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.Calculator.Core;

namespace Task5.Calculator.Tests
{
    [TestClass]
    public class TokenizerTester
    {
        private readonly ValueValidator _valueValiadator;
        public TokenizerTester()
        {
            _valueValiadator = new ValueValidator();
        }
        [TestMethod]
        public void Tokenizer_GetTokens_ShouldReturnListWithCorrectStringElemnts()
        {
            //Arrange
            Tokenizer tokenizer = new Tokenizer(_valueValiadator);
            string testExpression = "(2+11)+10";
            List<string> expectList = new List<string>() { "(", "2", "+", "11", ")", "+", "10" };
            //Act
            List<string> actualList = tokenizer.GetTokens(testExpression);
            //Assert
            CollectionAssert.AreEqual(expectList, actualList);
        }
    }
}
