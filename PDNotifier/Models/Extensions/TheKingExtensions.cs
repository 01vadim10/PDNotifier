using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PDNotifier.Models.Extensions
{
    public static class TheKingExtensions
    {
        public static string FindTheMostCommonName(this List<TheKing> kings)
        {
            var names = new Dictionary<string, int>();
            var theMostCommonName = "";

            //Split our name string to be able to get the firstname only
            //Put our firstname as a key of Dictionary and total count of usage this name in kings list
            for (int i = 0; i < kings.Count; i++)
            {
                var firstName = kings[i].Name.Split(' ').FirstOrDefault();

                if (!names.ContainsKey(firstName))
                    names.Add(firstName, 0);

                names[firstName]++;
            }

            var total = 0;

            //Search for the most common name
            foreach (var name in names)
            {
                if (name.Value > total)
                {
                    total = name.Value;
                    theMostCommonName = name.Key;
                }
            }

            return theMostCommonName;
        }

        public static (TheKing, int) KingRuledLonger(this List<TheKing> kings)
        {
            int maxYearsOfRule = int.MinValue;
            TheKing blessedKing = null;

            //Iterate through kings list and try find the longest ruled monarch
            for (int i = 0; i < kings.Count; i++)
            {
                var totalYears = FindYearsOfRule(kings[i].Years);

                if (totalYears > maxYearsOfRule)
                {
                    maxYearsOfRule = totalYears;
                    blessedKing = kings[i];
                }
            }

            return (blessedKing, maxYearsOfRule);
        }

        public static int FindYearsOfRule(List<string> listOfYears)
        {
            var totalYears = 0;

            for (int i = 0; i < listOfYears.Count; i++)
            {
                totalYears += FindYearsOfRule(listOfYears[i]);
            }

            return totalYears;
        }

        private static int FindYearsOfRule(string years)
        {
            //Split years string into array to be able to parse it into integer
            var yearsOfRule = years
                    .Split('-')
                    .Select(y =>
                    {
                        //Try parse our year string into integer class.
                        //If there is an empty string, it means we have a format like 1999-X,
                        //so instead of X we put current year because the king is still alive
                        return int.TryParse(y, out var y2)
                            ? y2
                            : DateTime.Now.Year;
                    })
                    .ToArray();

            //If we have only one year date in the array it means the king ruled only one year
            int lastYearOfRule = yearsOfRule.Length < 2
                ? yearsOfRule.FirstOrDefault() + 1
                : yearsOfRule[1];
            return lastYearOfRule - yearsOfRule[0];
        }
    }
}
