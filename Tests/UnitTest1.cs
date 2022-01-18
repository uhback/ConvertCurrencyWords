using NUnit.Framework;
using System;
using System.Collections.Generic;
using API.Data;

namespace Tests
{
    public class Tests
    {
        private Converts _converts = null;

        [SetUp]
        public void Setup()
        {
            _converts = new Converts();
        }

        [TestCase(0.05, "Five Cents")]
        [TestCase(9.5, "Nine Dollar and Fifty Cents")]
        [TestCase(10056.45, "Ten Thousand FiftySix Dollar and FourtyFive Cents")]
        public void ConvertCurrencyWords_Returns_CorrectWords(double number, string words)
        {
            int[] parts = _converts.SplitNumericToInteger(number);
            int intPart = parts[0];
            int decPart = parts[1];

            var wholeWords = new List<string>();

            if (intPart > 0)
                wholeWords.Add(string.Concat(_converts.ConvertNumToWords(intPart), " Dollar"));
            if (decPart > 0)
                wholeWords.Add(string.Concat(_converts.ConvertNumToWords(decPart), " Cents"));

            Assert.AreEqual(words, String.Join(" and ", wholeWords));
        }
    }
}