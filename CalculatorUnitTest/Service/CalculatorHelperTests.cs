using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.Service.Tests
{
    [TestClass()]
    public class CalculatorHelperTests
    {
        [TestMethod()]
        public void ConvertSpecialMultiplicationPatternTest()
        {
            var helper = new CalculatorHelper();
            var test1 = helper.ConvertSpecialMultiplicationPattern("5 ( 20 + 1 )");
            var test2 = helper.ConvertSpecialMultiplicationPattern("5 + 5 ( 20 + 1 )");
            var test3 = helper.ConvertSpecialMultiplicationPattern("( 5 ) ( 20 + 1 )");
            var test4 = helper.ConvertSpecialMultiplicationPattern("( 5 + 5 ) ( 20 + 1 )");
            var test5 = helper.ConvertSpecialMultiplicationPattern("( 5 ) 20");
            var test6 = helper.ConvertSpecialMultiplicationPattern("( 5 ) 20 + 1");
            var test7 = helper.ConvertSpecialMultiplicationPattern("( 5 ) ( 5 ) ( 5 )");
            var test8 = helper.ConvertSpecialMultiplicationPattern("( 5 ) ( 5 ) ( 20 + 1 )");

            Assert.AreEqual("5 * ( 20 + 1 )", test1);
            Assert.AreEqual("5 + 5 * ( 20 + 1 )", test2);
            Assert.AreEqual("( 5 ) * ( 20 + 1 )", test3);
            Assert.AreEqual("( 5 + 5 ) * ( 20 + 1 )", test4);
            Assert.AreEqual("( 5 ) * 20", test5);
            Assert.AreEqual("( 5 ) * 20 + 1", test6);
            Assert.AreEqual("( 5 ) * ( 5 ) * ( 5 )", test7);
            Assert.AreEqual("( 5 ) * ( 5 ) * ( 20 + 1 )", test8);
        }
    }
}