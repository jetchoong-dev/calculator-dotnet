using Calculator.Interface;
using CalculatorApp.Exceptions;
using CalculatorApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Calculator.Service
{
    public class ArithmeticsCalculator
    {
        InputValidator _validator;
        CalculatorHelper _helper;

        public ArithmeticsCalculator(InputValidator validator, CalculatorHelper helper)
        {
            _validator = validator;
            _helper = helper;
        }

        public string Calculate(string expression)
        {
            // input expression main validation
            _validator.ValidateInput(expression);

            // convert special multiplication expression pattern (if any)
            expression = _helper.ConvertSpecialMultiplicationPattern(expression);

            // validate expression operators
            _validator.ValidateMissingOperators(expression);

            // identify innermost brackets
            string pattern = @"\([^()]*\)";
            var regex = new Regex(pattern);
            var matched = regex.Matches(expression);

            // compute found innermost brackets and its expressions
            while (matched.Count > 0)
            {
                string value = Compute(matched[0].Value);
                expression = expression.Replace(matched[0].Value, value);
                matched = regex.Matches(expression);
                expression = _helper.ConvertSpecialMultiplicationPattern(expression);
            }

            return Compute(expression);
        }

        private string Compute(string expression)
        {
            // prepare to compute
            var bArithmetics = new BasicArithmetics();                        
            var characteres = new List<string>(expression.Trim().Split(' '));

            // remove empty space elements from the list
            characteres = characteres.Where(x => x != "").ToList();

            // remove brackets
            if (characteres.IndexOf(")") > -1) characteres.RemoveAt(characteres.IndexOf(")")); 
            if (characteres.IndexOf("(") > -1) characteres.RemoveAt(characteres.IndexOf("("));

            // check if expression ends with an operator, put here to check every short expression
            _validator.ValidateOperators(string.Join("", characteres));

            // check if operator presents, can't check during validation due to negative sign
            if (characteres.Count > 1 && characteres.IndexOf("+") < 0 && characteres.IndexOf("-") < 0 && characteres.IndexOf("*") < 0 && characteres.IndexOf("/") < 0)
            {
                throw new SyntaxException("Missing operator");
            }

            int workIndex = -1;

            // begins with multiplication and division
            while (characteres.IndexOf("*") > -1 || characteres.IndexOf("/") > -1)
            {
                int multiplicationIndex = characteres.IndexOf("*");
                int divisionIndex = characteres.IndexOf("/");

                if (multiplicationIndex > -1 && divisionIndex > -1)
                {
                    // if both multiplication and division present, work out the expression from left to right
                    if (multiplicationIndex < divisionIndex)
                    {
                        workIndex = multiplicationIndex;
                        characteres[workIndex] = bArithmetics.Multiplication(double.Parse(characteres[workIndex - 1]), double.Parse(characteres[workIndex + 1])).ToString();
                    }
                    else
                    {
                        workIndex = divisionIndex;
                        characteres[workIndex] = bArithmetics.Division(double.Parse(characteres[workIndex - 1]), double.Parse(characteres[workIndex + 1])).ToString();
                    }
                }
                else
                {
                    // multiplication 
                    if (multiplicationIndex > 0)
                    {
                        workIndex = multiplicationIndex;
                        characteres[workIndex] = bArithmetics.Multiplication(double.Parse(characteres[workIndex - 1]), double.Parse(characteres[workIndex + 1])).ToString();
                    }
                    // division
                    else if (divisionIndex > 0)
                    {
                        workIndex = divisionIndex;
                        characteres[workIndex] = bArithmetics.Division(double.Parse(characteres[workIndex - 1]), double.Parse(characteres[workIndex + 1])).ToString();
                    }
                }

                characteres.RemoveAt(workIndex + 1);
                characteres.RemoveAt(workIndex - 1);
            }

            // work with addition and subtraction subsequently
            while (characteres.IndexOf("+") > -1 || characteres.IndexOf("-") > -1)
            {
                if (characteres[1] == "+")
                {
                    // addition
                    characteres[1] = bArithmetics.Addition(double.Parse(characteres[0]), double.Parse(characteres[2])).ToString();
                    characteres.RemoveAt(2);
                    characteres.RemoveAt(0);
                }
                else if (characteres[1] == "-")
                {
                    // subtraction
                    characteres[1] = bArithmetics.Subtraction(double.Parse(characteres[0]), double.Parse(characteres[2])).ToString();
                    characteres.RemoveAt(2);
                    characteres.RemoveAt(0);
                }
                else if (characteres[0] == "+" || characteres[0] == "-")
                {
                    // insert 0 as initial value if input begins with "+" or "-"
                    characteres.Insert(0, "0");
                } 
            }

            return characteres[0];
        }
    }
}
