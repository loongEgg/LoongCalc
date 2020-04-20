using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LoongEgg.MathPro.Test
{
    // TODO: 32-2 数学表达式解析的单元测试
    [TestClass]
    public class Token_Test
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetTokenType_ThrowArgumentExeception() {
            Token.GetTokenType('.');             
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetTokenType_ThrowNullExeception() {
            Token.GetTokenType(null);             
        }

        [TestMethod]
        public void GetTokenType_OperandChar() {

            Assert.AreEqual(TokenType.Operand, Token.GetTokenType('0')); 
            Assert.AreEqual(TokenType.Operand, Token.GetTokenType('9')); 
        }
         
        [TestMethod]
        public void GetTokenType_Operator() {
            Assert.AreEqual(TokenType.Operator, Token.GetTokenType('+'));
            Assert.AreEqual(TokenType.Operator, Token.GetTokenType('-'));
            Assert.AreEqual(TokenType.Operator, Token.GetTokenType('*'));
            Assert.AreEqual(TokenType.Operator, Token.GetTokenType('+'));
            Assert.AreEqual(TokenType.Operator, Token.GetTokenType('^'));
        }

        [TestMethod]
        public void GetTokenType_Bracket() {
            Assert.AreEqual(TokenType.LeftBracket, Token.GetTokenType("("));
            Assert.AreEqual(TokenType.RightBracket, Token.GetTokenType(")"));
        }

        [TestMethod]
        public void GetTokenType_OperandString() {
            Assert.AreEqual(TokenType.Operand, Token.GetTokenType("89.9"));
            Assert.AreEqual(TokenType.Operand, Token.GetTokenType("89"));
        }

        [TestMethod]
        public void GetTokenType_Function() {
            Assert.AreEqual(TokenType.Function, Token.GetTokenType("Cos")); 
        }

        [TestMethod]
        public void Tokenize() {
            string str = "-2.3 *4 +(-2-Cos7)";
            var tokens = Token.Tokenize(str);
            Assert.AreEqual(10, tokens.Count);

            Assert.AreEqual(TokenType.Operand, tokens[0].Type);
            Assert.AreEqual("-2.3", tokens[0].NormalizeString);

            Assert.AreEqual(TokenType.Operator, tokens[1].Type);
            Assert.AreEqual("*", tokens[1].NormalizeString);

            Assert.AreEqual(TokenType.Operand, tokens[2].Type);
            Assert.AreEqual("4", tokens[2].NormalizeString);

            Assert.AreEqual(TokenType.Operator, tokens[3].Type);
            Assert.AreEqual("+", tokens[3].NormalizeString);

            Assert.AreEqual(TokenType.LeftBracket, tokens[4].Type);
            Assert.AreEqual("(", tokens[4].NormalizeString);

            Assert.AreEqual(TokenType.Operand, tokens[5].Type);
            Assert.AreEqual("-2", tokens[5].NormalizeString);

            Assert.AreEqual(TokenType.Operator, tokens[6].Type);
            Assert.AreEqual("-", tokens[6].NormalizeString);

            Assert.AreEqual(TokenType.Function, tokens[7].Type);
            Assert.AreEqual("cos", tokens[7].NormalizeString);

            Assert.AreEqual(TokenType.Operand, tokens[8].Type);
            Assert.AreEqual("7", tokens[8].NormalizeString);

            Assert.AreEqual(TokenType.RightBracket, tokens[9].Type);
            Assert.AreEqual(")", tokens[9].NormalizeString);
        }

    }
}
