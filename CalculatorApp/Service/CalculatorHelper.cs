using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CalculatorApp.Service
{
    public class CalculatorHelper
    {
        public string ConvertSpecialMultiplicationPattern(string expression)
        {
            // TODO: insert multiplication sign to applicable location, example
            // 5 ( 20 + 1 )     => 5 * ( 20 + 1 )
            // ( 5 ) ( 20 + 1 ) => ( 5 ) * ( 20 + 1 )
            // ( 5 ) 20         => ( 5 ) * 20 
            string pattern = @"(\))\s*(\d+)|(\d+)\s*(\()|(\))\s*(\()";
            var matched = Regex.Match(expression, pattern);

            while (matched.Success)
            {
                var values = new List<string> { };
                for (int i = 1; i < matched.Groups.Count; i++)
                {
                    if (!string.IsNullOrEmpty(matched.Groups[i].Value)) values.Add(matched.Groups[i].Value);
                }

                string newExpression = string.Join(" * ", values);
                expression = expression.Replace(matched.Value, newExpression);
                matched = Regex.Match(expression, pattern);
            }

            return expression;
        }
    }
}
