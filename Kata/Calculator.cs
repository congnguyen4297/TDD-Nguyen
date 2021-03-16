using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata
{
    public static class Calculator
    {
        public static int Calculate(string input)
        {
            if (input == "")
                return 0;

            input = input.TrimStart('#');

            var singleNumber = GetSingleNumber(input);
            if (singleNumber != null)
                return singleNumber.Value;

            var twoNumbersCommaDelim = input.Split(',');
            var twoCommaDelimSum = GetSumOfTwoNumber(twoNumbersCommaDelim);
            if (twoCommaDelimSum != null)
                return twoCommaDelimSum.Value;

            var twoNumbersNewLineDelim = input.Split('\n');
            var twoNewLineDelimSum = GetSumOfTwoNumber(twoNumbersNewLineDelim);
            if (twoNewLineDelimSum != null)
                return twoNewLineDelimSum.Value;

            var threeNumbers = input.Split('\n', ',');
            var threeNumbersSum = GetSumOfThreeNumber(threeNumbers);
            if (threeNumbersSum != null)
                return threeNumbersSum.Value;

            return int.MinValue;
        }

        private static int? GetSingleNumber(string input)
        {
            var isSingleNumber = Int32.TryParse(input, out int result);
            if (isSingleNumber)
            {
                if (result < 0)
                    throw new ArgumentException();
                else if (result > 1000)
                    return 0;
                return result;
            }
            return null;
        }

        private static int? GetSumOfTwoNumber(string[] twoNumbers)
        {
            if (twoNumbers.Length == 2)
            {
                var firstNum = GetSingleNumber(twoNumbers[0]);
                var secondNum = GetSingleNumber(twoNumbers[1]);
                if (firstNum != null && secondNum != null)
                    return firstNum.Value + secondNum.Value;
            }
            return null;
        }

        private static int? GetSumOfThreeNumber(string[] threeNumbers)
        {
            if (threeNumbers.Length == 3)
            {
                var firstSum = GetSumOfTwoNumber(new string[] { threeNumbers[0], threeNumbers[1] });
                var lastNumber = GetSingleNumber(threeNumbers[2]);
                if (firstSum != null && lastNumber != null)
                    return firstSum.Value + lastNumber.Value;
            }
            return null;
        }

    }
}
