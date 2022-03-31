using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Interface
{
    interface IBasicArithmetics
    {
        double Addition(double num1, double num2);
        double Subtraction(double num1, double num2);
        double Multiplication(double num1, double num2);
        double Division(double num1, double num2);
    }
}
