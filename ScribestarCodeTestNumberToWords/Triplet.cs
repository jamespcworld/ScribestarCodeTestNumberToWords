using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScribestarCodeTestNumberToWords
{
    public class Triplet
    {
        private readonly int[] _digits;
        private readonly int _tripletNumber;

        private Triplet(int[] digits, int tripletNumber)
        {
            _digits = digits;
            _tripletNumber = tripletNumber;
        }

        private bool HasOnes { get { return Length >= 1; } }
        private bool HasTens { get { return Length >= 2; } }
        private bool HasHundreds { get { return Length == 3; } }

        private int Ones
        {
            get { return _digits[0]; }
        }

        private int Tens
        {
            get { return _digits[1]; }
        }

        private int Hundreds
        {
            get { return _digits[2]; }
        }

        public int Length
        {
            get { return _digits.Length; }
        }

        public override string ToString()
        {
            var result = new List<string>();

            if (HasHundreds && Hundreds > 0)
            {
                // appent multiplier
                result.Add(NumberNames.Ones[Hundreds]);

                // append hundred
                result.Add(NumberNames.Triplets[0]);
            }

            if (HasTens && Tens > 0)
            {
                // tens are beetween 11 and 19
                if (Tens > 0 && Tens < 2)
                {
                    result.Add(NumberNames.Teens[Ones]);
                }
                // tens are greater then 19
                else if (Tens >= 2)
                {
                    result.Add(NumberNames.Tens[Tens - 2]);
                }
            }

            if (HasOnes)
            {
                // append zero only if there is one triplet and a single digit
                if (Ones == 0 && Length == 1 && _tripletNumber == 0)
                {
                    result.Add(NumberNames.Ones[Ones]);
                }
                else if (Length == 1 || (Length == 3 && Tens == 0 && Ones != 0))
                {
                    result.Add(NumberNames.Ones[Ones]);
                }
                else if (HasTens && Tens >= 2 && Ones > 0)
                {
                    result.Add(NumberNames.Ones[Ones]);
                }
            }
            return string.Join(" ", result);
        }

        // gets digits for a triplet
        private static int[] GetDigits(IReadOnlyCollection<int> digits, int tripletNumber)
        {
            var from = tripletNumber * 3;
            var to = tripletNumber * 3 + 2;

            var lastIndex = digits.Count - 1;

            if (from > lastIndex)
            {
                return null;
            }

            if (to > lastIndex)
            {
                to = lastIndex;
            }

            var tripletDigits = digits.Where((digit, i) => i >= from && i <= to).ToArray();
            return tripletDigits;
        }

        public static string ToText(int[] digits, int tripletNumber)
        {
            var tripletDigits = GetDigits(digits, tripletNumber);
            var triplet = new Triplet(tripletDigits, tripletNumber);
            return triplet.ToString();
        }
    }

}
