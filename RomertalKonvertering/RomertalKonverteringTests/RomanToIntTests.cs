using RomertalKonvertering;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RomertalKonverteringTests
{
    public class RomanToIntTests
    {
        [Theory]
        [InlineData("MMMCMXCIX", 3999)]
        [InlineData("MMM", 3000)]
        [InlineData("I", 1)]
        public void RomanToInt_RomanNumerals_ReturnConvertedNumber(string romanNumeralInput, int expectedNumber)
        {
            RomanNumeral romanNumeral = new(romanNumeralInput);
            int actualNumber = romanNumeral.IntegerValue;


            Assert.Equal(expectedNumber, actualNumber);
        }

        [Fact]
        public void RomanToInt_WhenTheInputStringIsNull_ShouldThrowException()
        {
            string? romanNumeralInput = null;
            string expectedErrorMessage = "The string is null";

            Action act = () => new RomanNumeral(romanNumeralInput);

            Exception e = Assert.Throws<Exception>(act);
            Assert.Equal(expectedErrorMessage, e.Message);
        }

        [Theory]
        [InlineData("MMMCMXCIXZ", "The letter Z is not a valid roman letter")]
        [InlineData("MMMM", "The roman numeral MMMM is above max value with the value 4000")]
        public void RomanToInt_WhenTheInputStringIsInvalid_ShouldThrowInvalidRomanNumeralException(string? romanNumeralInput, string expectedErrorMessage)
        {
            Action act = () => new RomanNumeral(romanNumeralInput);

            InvalidRomanNumeralException e = Assert.Throws<InvalidRomanNumeralException>(act);
            Assert.Equal(expectedErrorMessage, e.Message);
        }
    }
}
