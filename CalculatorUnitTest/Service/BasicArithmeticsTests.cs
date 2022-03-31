using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Service.Tests
{
    [TestClass()]
    public class BasicArithmeticsTests
    {
        [TestMethod()]
        public void AdditionTest()
        {
            var bArithmetics = new BasicArithmetics();
            Assert.AreEqual(0, bArithmetics.Addition(-5, 5));
            Assert.AreEqual(20, bArithmetics.Addition(10, 10));
        }

        [TestMethod()]
        public void SubtractionTest()
        {
            var bArithmetics = new BasicArithmetics();
            Assert.AreEqual(-10, bArithmetics.Subtraction(-5, 5));
            Assert.AreEqual(0, bArithmetics.Subtraction(10, 10));
        }

        [TestMethod()]
        public void MultiplicationTest()
        {
            var bArithmetics = new BasicArithmetics();
            Assert.AreEqual(-25, bArithmetics.Multiplication(-5, 5));
            Assert.AreEqual(0, bArithmetics.Multiplication(0, 10));
        }

        [TestMethod()]
        public void DivisionTest()
        {
            var bArithmetics = new BasicArithmetics();
            Assert.AreEqual(2, bArithmetics.Division(10, 5));
        }

        [TestMethod()]
        public void DivisionDivideByZeroExceptionTest()
        {
            var bArithmetics = new BasicArithmetics();

            Assert.ThrowsException<DivideByZeroException>(() =>
            {
                bArithmetics.Division(10, 0);
            });
        }
    }
}