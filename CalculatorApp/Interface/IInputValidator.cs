using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Interface
{
    public interface IInputValidator
    {
        void ValidateInput(string expression);
        void ValidateOperators(string expression);
    }
}
