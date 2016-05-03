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

            if (numbers.Contains(','))
            {
                string[] numbersToAdd = numbers.Split(',');
                int firstNumber;
                int secondNumber;
                int.TryParse(numbersToAdd[0], out firstNumber);
                int.TryParse(numbersToAdd[1], out secondNumber);
                returnValue = firstNumber + secondNumber;
            }
            else
            {
                int.TryParse(numbers, out returnValue);
            }
            return returnValue;
        }
    }
}
