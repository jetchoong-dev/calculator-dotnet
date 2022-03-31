using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorApp.Exceptions;

namespace Calculator.Service.Tests
{
    [TestClass()]
    public class ArithmeticsCalculatorTests
    {
        [TestMethod()]
        public void CalculateBasicTest()
        {
            var calculator = new ArithmeticsCalculator("1 + 1");
            Assert.AreEqual("2", calculator.Calculate());

            calculator.Expression = "2 * 2";
            Assert.AreEqual("4", calculator.Calculate());

            calculator.Expression = "1 + 2 + 3";
            Assert.AreEqual("6", calculator.Calculate());

            calculator.Expression = "6 / 2";
            Assert.AreEqual("3", calculator.Calculate());

            calculator.Expression = "11 + 23";
            Assert.AreEqual("34", calculator.Calculate());

            calculator.Expression = "11.1 + 23";
            Assert.AreEqual("34.1", calculator.Calculate());

            calculator.Expression = "1 + 1 * 3";
            Assert.AreEqual("4", calculator.Calculate());

            // extra tests with negative values
            calculator.Expression = "8 + -8";
            Assert.AreEqual("0", calculator.Calculate());

            calculator.Expression = "8 - -8";
            Assert.AreEqual("16", calculator.Calculate());

            calculator.Expression = "-8 + 8";
            Assert.AreEqual("0", calculator.Calculate());

            calculator.Expression = "-8 - -8";
            Assert.AreEqual("0", calculator.Calculate());

            calculator.Expression = "8 / -1";
            Assert.AreEqual("-8", calculator.Calculate());

            calculator.Expression = "-8 / 1";
            Assert.AreEqual("-8", calculator.Calculate());

            calculator.Expression = "-8 / -1";
            Assert.AreEqual("8", calculator.Calculate());

            calculator.Expression = "-8 * -1";
            Assert.AreEqual("8", calculator.Calculate());

            calculator.Expression = "-8 * 1";
            Assert.AreEqual("-8", calculator.Calculate());

            calculator.Expression = "-8 * 1";
            Assert.AreEqual("-8", calculator.Calculate());

            calculator.Expression = "-8 * -1 * -1";
            Assert.AreEqual("-8", calculator.Calculate());

            calculator.Expression = "5 ( 20 + 1 )";
            Assert.AreEqual("105", calculator.Calculate());

            calculator.Expression = "5 + 5 ( 20 + 1 )";
            Assert.AreEqual("110", calculator.Calculate());

            calculator.Expression = "( 5 ) ( 20 + 1 )";
            Assert.AreEqual("105", calculator.Calculate());

            calculator.Expression = "( 5 + 5 ) ( 20 + 1 )";
            Assert.AreEqual("210", calculator.Calculate());

            calculator.Expression = "( 5 ) 20";
            Assert.AreEqual("100", calculator.Calculate());

            calculator.Expression = "( 5 ) 20 + 1";
            Assert.AreEqual("101", calculator.Calculate());

            calculator.Expression = "( 5 ) ( 5 ) ( 5 )";
            Assert.AreEqual("125", calculator.Calculate());

            calculator.Expression = "( 5 ) ( 5 ) ( 20 + 1 )";
            Assert.AreEqual("525", calculator.Calculate());

        }

        [TestMethod()]
        public void CalculateWithBracketsTest()
        {
            var calculator = new ArithmeticsCalculator("( 11.5 + 15.4 ) + 10.1");
            Assert.AreEqual("37", calculator.Calculate());

            calculator.Expression = "23 - ( 29.3 - 12.5 )";
            Assert.AreEqual("6.2", calculator.Calculate());

            calculator.Expression = "( 1 / 2 ) - 1 + 1";
            Assert.AreEqual("0.5", calculator.Calculate());
        }

        [TestMethod()]
        public void CalculateAdvancedTest()
        {
            var calculator = new ArithmeticsCalculator("10 - ( 2 + 3 * ( 7 - 5 ) )");
            Assert.AreEqual("2", calculator.Calculate());

            calculator.Expression = "7 - ( ( - 8 ) ( 1 ) )";
            Assert.AreEqual("15", calculator.Calculate());

            calculator.Expression = "- 3 ( -3 ) + 1";
            Assert.AreEqual("10", calculator.Calculate());

            calculator.Expression = "- 3 / ( -3 ) + 1";
            Assert.AreEqual("2", calculator.Calculate());

            calculator.Expression = "- 3 ( 5 ) + 1 ( -6 )";
            Assert.AreEqual("-21", calculator.Calculate());

            Assert.ThrowsException<SyntaxException>(() =>
            {

                calculator.Expression = "-8 -8";
                calculator.Calculate();
            });
        }
    }
}