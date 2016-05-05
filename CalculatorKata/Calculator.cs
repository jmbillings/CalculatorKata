using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CalculatorKata
{
    public class Calculator
    {
        // Kata from http://osherove.com/tdd-kata-1/

        public int Add(string numbers)
        {
            if (numbers == string.Empty)
                return 0;

            return AddMultipleNumbers(numbers);
        }

        private int AddMultipleNumbers(string numbers)
        {
            string[] numbersToAdd = numbers.Split(GetDelimiters(numbers), StringSplitOptions.RemoveEmptyEntries);
            int returnValue = 0;
            StringBuilder negativeNumbers = new StringBuilder();

            foreach (var number in numbersToAdd)
            {
                int currentNumber;
                int.TryParse(number, out currentNumber);
                if (currentNumber < 0)
                    negativeNumbers.Append(' ' + number);

                if (currentNumber < 1001)
                    returnValue = returnValue + currentNumber;
            }

            if (negativeNumbers.Length > 0)
            {
                //we have some negative numbers
                throw new Exception("negatives not allowed" + negativeNumbers.ToString());
            }

            return returnValue;
        }

        private string[] GetDelimiters(string numbers)
        {
            if (numbers.StartsWith("//"))
            {
                //Get the Custom delimiter...
                string customDelimiter = GetCustomDelimiter(numbers);

                return new[] { customDelimiter, ",", "\n" }; //custom delimiter character will be 3rd in string
            }

            return new[] { ",", "\n" };
        }

        private string GetCustomDelimiter(string numbers)
        {
            string delimiterExtractingRegex = @"(?<=\/\/\[).+?(?=\])";

            foreach (Match match in Regex.Matches(numbers, delimiterExtractingRegex, RegexOptions.Multiline))
            {
                return match.ToString();
            }
            //if no match, we might have a single length delimiter
            return numbers[2].ToString();
        }
    }
}
