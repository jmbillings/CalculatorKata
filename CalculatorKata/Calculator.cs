using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorKata
{
    public class Calculator
    {
        // Kata from http://osherove.com/tdd-kata-1/

        public int Add(string numbers)
        {
            if (numbers == string.Empty)
                return 0;

            int returnValue;
            int.TryParse(numbers, out returnValue);
            return returnValue;
        }
    }
}
