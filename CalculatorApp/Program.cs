using Calculator.Service;
using CalculatorApp.Exceptions;
using System;
using System.Collections.Generic;

namespace CalculatorApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--Calculator App, type \"quit\" to exit application--\n");

            do
            {
                try
                {
                    Console.WriteLine("Please enter expression");
                    string expression = Console.ReadLine();

                    if (string.Equals(expression, "quit", StringComparison.OrdinalIgnoreCase)) break;
                    if (string.IsNullOrEmpty(expression)) continue;

                    var calculator = new ArithmeticsCalculator(expression);
                    string answer = calculator.Calculate();

                    Console.WriteLine($"Answer => {answer} \n");
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine($"Math error => {ex.Message} \n");
                }
                catch (SyntaxException ex)
                {
                    Console.WriteLine($"Syntax error => {ex.Message} \n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Application error => {ex.Message} \n");
                }
            }
            while (true);
        }
    }
}
