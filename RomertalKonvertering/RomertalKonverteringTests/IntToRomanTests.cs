using RomertalKonvertering;
using System;

namespace RomertalKonverteringTests
{
    public class IntToRomanTests
    {
        [Theory]
        [InlineData(3999, "MMMCMXCIX")]
        [InlineData(277, "CCLXXVII")]
        [InlineData(21, "XXI")]
        [InlineData(2, "II")]
        public void IntToRoman_UpToAllFourDigits_ReturnConvertedRomanNumerals(int number, string expectedRomanNumeral)
        {
            RomanNumeral romanNumeral = new(number);
            string? actualRomanNumeral = romanNumeral.RomanNumeralStr;

            Assert.Equal(expectedRomanNumeral, actualRomanNumeral);
        }

        [Theory]
        [InlineData(4000, "The number 4000 is above max")]
        [InlineData(-400, "The number -400 is negative")]
        public void IntToRoman_WhenTheIntegerIsHigerThanTheMaxValueOrNegative_ShouldThrowInvalidNumberException(int number, string expectedErrorMessage)
        {

            Action act = () => new RomanNumeral(number);

            InvalidNumberException e = Assert.Throws<InvalidNumberException>(act);
            Assert.Equal(expectedErrorMessage, e.Message);
        }
    }
}