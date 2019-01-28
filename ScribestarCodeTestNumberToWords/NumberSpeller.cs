using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScribestarCodeTestNumberToWords
{

    public  class NumberSpeller: INumberSpeller
    {
        public string SpellNumber(int number)
        {
            // parse digits and reverse their order
            var digits = number.ToString().Select(digit => int.Parse(digit.ToString())).Reverse().ToArray();

            var numberNames = new List<string>();

            // calc the number of triplets
            var tripletCount = (int)Math.Ceiling(digits.Length / 3.0);

            for (var tripletNumber = 0; tripletNumber < tripletCount; tripletNumber++)
            {
                var triplet = Triplet.ToText(digits, tripletNumber);
                if (string.IsNullOrEmpty(triplet))
                {
                    continue;
                }

                // add thousands multiplier if there is more then one triplet and we already have the first one
                if (tripletCount > 0 && tripletNumber > 0)
                {
                    numberNames.Add(NumberNames.Triplets[tripletNumber]);
                }

                numberNames.Add(triplet);
            }

            // join all triplets
            var result = string.Join(" ", numberNames.AsEnumerable().Reverse());
            return result;
        }
    }
}
