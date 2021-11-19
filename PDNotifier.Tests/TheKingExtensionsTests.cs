using PDNotifier.Models;
using PDNotifier.Models.Extensions;
using System.Collections.Generic;
using Xunit;

namespace PDNotifier.Tests
{
    public class TheKingExtensionsTests
    {
        [Theory]
        [MemberData(nameof(ListOfKings))]
        public void TheMostCommonNameTest(List<TheKing> kings, string expected)
        {
            var name = kings.FindTheMostCommonName();
            Assert.Equal(expected, name);
        }

        public static IEnumerable<object[]> ListOfKings => new List<object[]>
        {
            new object[]
            {
                new List<TheKing>
                {
                    new TheKing
                    {
                        Name = "King1",
                        Country = "Kingdom1",
                        House = "HouseName1",
                        Years = "4"
                    },new TheKing
                    {
                        Name = "King4",
                        Country = "Kingdom2",
                        House = "HouseName2",
                        Years = "2"
                    },new TheKing
                    {
                        Name = "King3",
                        Country = "Kingdom3",
                        House = "HouseName3",
                        Years = "1"
                    },new TheKing
                    {
                        Name = "King4",
                        Country = "Kingdom1",
                        House = "HouseName1",
                        Years = "4"
                    },
                },
                "King4"
            }
        };
    }
}
