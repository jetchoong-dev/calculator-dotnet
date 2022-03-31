using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorApp.Exceptions;

namespace CalculatorApp.Service.Tests
{
    [TestClass()]
    public class InputValidatorTests
    {
        [TestMethod()]
        public void ValidateInputTest()
        {
            var validator = new InputValidator();
            validator.ValidateInput("1 + 2");
            validator.ValidateInput("1 + ( 2 * 3 )");
            validator.ValidateInput("5.55 / ( 2.3 + -3.0 )");
        }

        [TestMethod()]
        public void ValidateInputSyntaxExceptionTest()
        {
            var validator = new InputValidator();

            Assert.ThrowsException<SyntaxException>(() =>
            {
                validator.ValidateInput("1");
            });
            Assert.ThrowsException<SyntaxException>(() =>
            {
                validator.ValidateInput("a");
            });
            Assert.ThrowsException<SyntaxException>(() =>
            {
                validator.ValidateInput("a + 1");
            });
            Assert.ThrowsException<SyntaxException>(() =>
            {
                validator.ValidateInput("[ ] > <");
            });
            Assert.ThrowsException<SyntaxException>(() =>
            {
                validator.ValidateInput("-8 8");
            });
            Assert.ThrowsException<SyntaxException>(() =>
            {
                validator.ValidateInput("( ) (");
            });
            Assert.ThrowsException<SyntaxException>(() =>
            {
                validator.ValidateInput("( ( ( ) )");
            });
            Assert.ThrowsException<SyntaxException>(() =>
            {
                validator.ValidateInput("()");
            });
            Assert.ThrowsException<SyntaxException>(() =>
            {
                validator.ValidateInput("( )");
            });
            Assert.ThrowsException<SyntaxException>(() =>
            {
                validator.ValidateInput("8 8 8");
            });
            Assert.ThrowsException<SyntaxException>(() =>
            {
                validator.ValidateInput("8 +- -8");
            });
            Assert.ThrowsException<SyntaxException>(() =>
            {
                validator.ValidateInput("8 +/* 8");
            });
            Assert.ThrowsException<SyntaxException>(() =>
            {
                validator.ValidateInput("8/ 8");
            });
            Assert.ThrowsException<SyntaxException>(() =>
            {
                validator.ValidateInput("8+* 8");
            });
            Assert.ThrowsException<SyntaxException>(() =>
            {
                validator.ValidateInput("8 *8");
            });
            Assert.ThrowsException<SyntaxException>(() =>
            {
                validator.ValidateInput("8*/8");
            });
            Assert.ThrowsException<SyntaxException>(() =>
            {
                validator.ValidateInput("8-+8");
            });
            Assert.ThrowsException<SyntaxException>(() =>
            {
                validator.ValidateInput("8 +-8");
            });
            Assert.ThrowsException<SyntaxException>(() =>
            {
                validator.ValidateInput("8*/ 8");
            });
            Assert.ThrowsException<SyntaxException>(() =>
            {
                validator.ValidateInput("8*/ +-8");
            });
        }

        [TestMethod()]
        public void ValidateOperatorsTest()
        {
            var validator = new InputValidator();
            validator.ValidateOperators("1 + 2");
            validator.ValidateOperators("1 + ( 2 * 3 )");
            validator.ValidateOperators("5.55 / ( 2.3 + -3.0 )");
        }

        [TestMethod()]
        public void ValidateOperatorsSyntaxExceptionTest()
        {
            var validator = new InputValidator();
            Assert.ThrowsException<SyntaxException>(() =>
            {
                validator.ValidateOperators("( 1 + 2 ) -");
            });
            Assert.ThrowsException<SyntaxException>(() =>
            {
                validator.ValidateOperators("1 + ");
            });
            Assert.ThrowsException<SyntaxException>(() =>
            {
                validator.ValidateOperators("* 1");
            });
            Assert.ThrowsException<SyntaxException>(() =>
            {
                validator.ValidateOperators("/ 1 + 2");
            });
            Assert.ThrowsException<SyntaxException>(() =>
            {
                validator.ValidateOperators("/ 1 + 2 -");
            });
        }
    }
}