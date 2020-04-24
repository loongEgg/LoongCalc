using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LoongEgg.MathSimple.Test
{
    [TestClass]
    public class StringExtensions_Test
    {
        [TestMethod]
        public void IsOperator() {
            Assert.IsTrue("+".IsOperator());
        }


         [TestMethod]
        public void IsFunction() {
            Assert.IsTrue("Cos".IsFunction());
            Assert.IsFalse("+".IsFunction());
        }

         [TestMethod]
        public void IsOperand() {
            Assert.IsTrue("233.3".IsOperand()); 
        }
    }
}
