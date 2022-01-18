using System;
using System.Globalization;

namespace API.Data
{
    public class Converts
    {
        private string[] units = new string[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        private string[] tens = new string[] { "Zero", "Ten", "Twenty", "Thirty", "Fourty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

        public int[] SplitNumericToInteger(double n)
        {
            // To validate the input value - length check
            var tempValues = n.ToString().Split('.');
            // Must be splitted into 2 and Cents should have 2 digits
            if (tempValues.Length != 2 || tempValues[1].Length > 2)
                throw new Exception($"Not valid input value: {n}");
            
            // Actual split
            var values = n.ToString("0.00").Split('.');
            return new int[] { int.Parse(values[0]), int.Parse(values[1]) };
        }
        public string ConvertNumToWords(int num)
        {
            string words = string.Empty;

            if ((num / 1000000000) > 0)
            {
                words += ConvertNumToWords(num / 1000000000) + " Billion ";
                num %= 1000000000;
            }

            if ((num / 1000000) > 0)
            {
                words += ConvertNumToWords(num / 1000000) + " Million ";
                num %= 1000000;
            }

            if ((num / 1000) > 0)
            {
                words += ConvertNumToWords(num / 1000) + " Thousand ";
                num %= 1000;
            }

            if ((num / 100) > 0)
            {
                words += ConvertNumToWords(num / 100) + " Hundred ";
                num %= 100;
            }

            if (num > 0)
            {
                if (num < 20)
                    words += units[num];
                else
                {
                    words += tens[num / 10];
                    if ((num % 10) > 0)
                        words += units[num % 10];
                }
            }

            return words;
        }
    }
}