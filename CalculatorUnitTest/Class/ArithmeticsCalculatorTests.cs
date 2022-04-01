using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorApp.Exceptions;
using CalculatorApp.Service;

namespace Calculator.Service.Tests
{
    [TestClass()]
    public class ArithmeticsCalculatorTests
    {
        [TestMethod()]
        public void CalculateBasicTest()
        {
            var calculator = new ArithmeticsCalculator(new InputValidator(), new CalculatorHelper());
            Assert.AreEqual("2", calculator.Calculate("1 + 1"));
            Assert.AreEqual("4", calculator.Calculate("2 * 2"));
            Assert.AreEqual("6", calculator.Calculate("1 + 2 + 3"));
            Assert.AreEqual("3", calculator.Calculate("6 / 2"));
            Assert.AreEqual("34", calculator.Calculate("11 + 23"));
            Assert.AreEqual("34.1", calculator.Calculate("11.1 + 23"));
            Assert.AreEqual("4", calculator.Calculate("1 + 1 * 3"));

            // extra tests with negative values
            Assert.AreEqual("0", calculator.Calculate("8 + -8"));
            Assert.AreEqual("16", calculator.Calculate("8 - -8"));
            Assert.AreEqual("0", calculator.Calculate("-8 + 8"));
            Assert.AreEqual("0", calculator.Calculate("-8 - -8"));
            Assert.AreEqual("-8", calculator.Calculate("8 / -1"));
            Assert.AreEqual("-8", calculator.Calculate("-8 / 1"));
            Assert.AreEqual("8", calculator.Calculate("-8 / -1"));
            Assert.AreEqual("8", calculator.Calculate("-8 * -1"));
            Assert.AreEqual("-8", calculator.Calculate("-8 * 1"));
            Assert.AreEqual("-8", calculator.Calculate("-8 * 1"));
            Assert.AreEqual("-8", calculator.Calculate("-8 * -1 * -1"));
            Assert.AreEqual("105", calculator.Calculate("5 ( 20 + 1 )"));
            Assert.AreEqual("110", calculator.Calculate("5 + 5 ( 20 + 1 )"));
            Assert.AreEqual("105", calculator.Calculate("( 5 ) ( 20 + 1 )"));
            Assert.AreEqual("210", calculator.Calculate("( 5 + 5 ) ( 20 + 1 )"));
            Assert.AreEqual("100", calculator.Calculate("( 5 ) 20"));
            Assert.AreEqual("101", calculator.Calculate("( 5 ) 20 + 1"));
            Assert.AreEqual("125", calculator.Calculate("( 5 ) ( 5 ) ( 5 )"));
            Assert.AreEqual("525", calculator.Calculate("( 5 ) ( 5 ) ( 20 + 1 )"));
        }

        [TestMethod()]
        public void CalculateWithBracketsTest()
        {
            var calculator = new ArithmeticsCalculator(new InputValidator(), new CalculatorHelper());
            Assert.AreEqual("37", calculator.Calculate("( 11.5 + 15.4 ) + 10.1"));
            Assert.AreEqual("6.2", calculator.Calculate("23 - ( 29.3 - 12.5 )"));
            Assert.AreEqual("0.5", calculator.Calculate("( 1 / 2 ) - 1 + 1"));
        }

        [TestMethod()]
        public void CalculateAdvancedTest()
        {
            var calculator = new ArithmeticsCalculator(new InputValidator(), new CalculatorHelper());
            Assert.AreEqual("2", calculator.Calculate("10 - ( 2 + 3 * ( 7 - 5 ) )"));
            Assert.AreEqual("15", calculator.Calculate("7 - ( ( - 8 ) ( 1 ) )"));
            Assert.AreEqual("10", calculator.Calculate("- 3 ( -3 ) + 1"));
            Assert.AreEqual("2", calculator.Calculate("- 3 / ( -3 ) + 1"));
            Assert.AreEqual("-21", calculator.Calculate("- 3 ( 5 ) + 1 ( -6 )"));
            Assert.ThrowsException<SyntaxException>(() =>
            {

                calculator.Calculate("-8 -8");
            });
        }
    }
}