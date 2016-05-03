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

            if (numbers.Contains(',') || numbers.Contains('\n'))
            {
                return AddMultipleNumbers(numbers);
            }

            int.TryParse(numbers, out returnValue);
            if (returnValue < 0)
                throw new Exception("negatives not allowed " + numbers);
            return returnValue;
        }

        private int AddMultipleNumbers(string numbers)
        {
            string[] numbersToAdd = numbers.Split(GetDelimiters(numbers));
            int returnValue = 0;
            StringBuilder negativeNumbers = new StringBuilder();

            foreach (var number in numbersToAdd)
            {
                int currentNumber;
                int.TryParse(number, out currentNumber);
                if (currentNumber < 0)
                    negativeNumbers.Append(' ' + number);

                returnValue = returnValue + currentNumber;
            }

            if (negativeNumbers.Length > 0)
            {
                //we have some negative numbers
                throw new Exception("negatives not allowed" + negativeNumbers.ToString());
            }

            return returnValue;
        }

        private char[] GetDelimiters(string numbers)
        {
            if (numbers.StartsWith("//"))
            {
                return new char[] { numbers[2], ',', '\n' }; //custom delimiter character will be 3rd in string
            }

            return new char[] { ',', '\n' };
        }
    }
}
