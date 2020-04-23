using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LoongEgg.LoongLogger;

namespace LoongEgg.MathPro.Test
{
    [TestClass]
    public class ReversPolishNotation_Test
    {
        [TestMethod]
        public void ConvertToPostFix() {
            Logger.EnableAll();
            
            var exp = "3 + 9*5-Cos30";
            Logger.WriteInfor($"Expression: {exp} ");

            var tokens = Token.Tokenize(exp);
            var postFix = ReversePolishNotation.ConvertToPostFix(tokens);
            var actual = ReversePolishNotation.EvaluatePostFix(postFix);

            double expected = 3.0 + 9.0* 5.0 - Math.Cos(30.0 * Math.PI / 180.0);
            Assert.AreEqual(expected.ToString("f3"), actual.ToString("f3"));

            Logger.Disable();
        }
    }
}
