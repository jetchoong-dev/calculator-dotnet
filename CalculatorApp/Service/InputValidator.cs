using Calculator.Interface;
using CalculatorApp.Exceptions;
using System.Linq;
using System.Text.RegularExpressions;

namespace CalculatorApp.Service
{
    public class InputValidator : IInputValidator
    {
        public void ValidateInput(string expression)
        {
            // only allow numbers 0-9, brackets, spaces & operators
            string pattern1 = @"[^\d*\.?\d*()\s\+\-\/\*]";
            var matched1 = Regex.Match(expression, pattern1);
            if (matched1.Success)
                throw new SyntaxException($"Invalid character found in expression, only allow numbers 0-9, brackets {"("} {")"} & operators {"+"} {"-"} {"*"} {"/"} ");

            // check if there is no operator
            string pattern2 = @"[\+\-\*\/]";
            var matched2 = Regex.Match(expression, pattern2);
            if (!matched2.Success)
                throw new SyntaxException("Missing operator");

            // identify mismatched brackets
            if (expression.Count(e => e == '(') != expression.Count(e => e == ')'))
                throw new SyntaxException("Mismatched brackets found");

            // identify mismatched brackets 
            var chars = expression.ToCharArray();
            chars = chars.Where(c => c == '(' || c == ')').ToArray();
            string brackets = string.Join("", chars);
            while (brackets.IndexOf("()") > -1)
            {
                brackets = brackets.Replace("()", "");
            }
            if (!string.IsNullOrEmpty(brackets))
            {
                throw new SyntaxException("Mismatched brackets found");
            }

            // identify empty brackets 
            string pattern3 = @"\(\s*\)";
            var matched3 = Regex.Match(expression, pattern3);
            if (matched3.Success)
                throw new SyntaxException("Empty brackets found");

            // identify consecutive numbers
            string pattern4 = @"\d+\s+\d+"; 
            var matched4 = Regex.Match(expression, pattern4);
            if (matched4.Success)
                throw new SyntaxException("Consecutive numbers or operators found");

            // identify misplaced operator 
            string pattern5 = @"[\+\-\/\*]\s*[\+\-\/\*]\s+|\d+[\+\-\/\*]|[\*\/]\d+|[\+\-\*\/][\+\-\*\/]\d+";
            var matched5 = Regex.Match(expression, pattern5);
            if (matched5.Success)
                throw new SyntaxException("Misplaced operator found");


        }

        public void ValidateOperators(string expression)
        {
            // check if an expression starts with "*", "/" or ends with an operator
            string pattern = @"^\s*[\/\*]|[\+\-\/\*]\s*$";
            var matched = Regex.Match(expression, pattern);
            if (matched.Success)
                throw new SyntaxException("Misplaced operator found");
        }
    }
}
