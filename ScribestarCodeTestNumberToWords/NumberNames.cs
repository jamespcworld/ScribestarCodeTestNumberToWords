using System;
using System.Collections.Generic;
using System.Text;

namespace ScribestarCodeTestNumberToWords
{
    public static class NumberNames
    {
        public static readonly string[] Ones =
        {
            "Zero",
            "One",
            "Two",
            "Three",
            "Four",
            "Five",
            "Six",
            "Seven",
            "Eight",
            "Nine",
        };

        public static readonly string[] Teens =
        {
            "Ten",
            "Eleven",
            "Twelve",
            "Thirteen",
            "Fourteen",
            "Fifteen",
            "Sixteen",
            "Seventeen",
            "Eighteen",
            "Nineteen"
        };

        public static readonly string[] Tens =
        {
            "Twenty",
            "Thirty",
            "Forty",
            "Fifty",
            "Sixty",
            "Seventy",
            "Eighty",
            "Ninety"
        };

        // this allows to easily extend the spellable number
        public static readonly string[] Triplets =
        {
            "Hundred",
            "Thousand",
            "Million",
            "Billion",
        };
    }
}
