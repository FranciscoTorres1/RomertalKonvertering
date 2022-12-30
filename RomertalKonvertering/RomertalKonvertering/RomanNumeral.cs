namespace RomertalKonvertering
{
    public class RomanNumeral
    {
        private readonly Dictionary<char, int> _romanNumbersDic = new() {
                {'I', 1}, {'V', 5}, {'X', 10}, {'L', 50}, 
                {'C', 100}, {'D', 500}, {'M', 1000} };

        private readonly string[,] _RomanConstants = new string[,] { 
            { "", "M", "MM", "MMM", "", "", "", "", "", ""}, 
            { "", "C", "CC",  "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM"}, 
            { "", "X", "XX",  "XXX", "XL","L", "LX", "LXX", "LXXX", "XC"}, 
            { "", "I", "II",  "III", "IV","V", "VI", "VII", "VIII", "IX"} };

        private string? _romanNumeral;
        private int _integerValue;

        public string? RomanNumeralStr { get => _romanNumeral; set => _romanNumeral = value; }
        public int IntegerValue { get => _integerValue; set => _integerValue = value; }

        public RomanNumeral(string? romanNumeralStr)
        {
            this._integerValue = RomanToInt(romanNumeralStr);
            this._romanNumeral = romanNumeralStr;
        }

        public RomanNumeral(int romanNumberInt)
        {
            this._romanNumeral = IntToRoman(romanNumberInt);
            this._integerValue = romanNumberInt;
        }

        public string? IntToRoman(int number)
        {
            string result = "";
            if (number > 3999)
                throw new InvalidNumberException("The number " + number + " is above max");

            if(number < 1)
                throw new InvalidNumberException("The number " + number + " is negative");


            string numberStr = number.ToString();

            for (int i = 0; i < numberStr.Length; i++)
            {
                int digitIndex = 4 - numberStr.Length + i;
                result += _RomanConstants[digitIndex, (int) Char.GetNumericValue(numberStr[i])];
            }

            return result;
        }

        public int RomanToInt(string? romanNumeralStr)
        {
            int result = 0;
            if (romanNumeralStr is null)
                throw new Exception("The string is null");

            if (romanNumeralStr.Length == 1)
               return TryGetNumberValue(romanNumeralStr[0]);

            for (int i = 0; i < romanNumeralStr.Length - 1; i++)
            {
                int currRomanNumeral = TryGetNumberValue(romanNumeralStr[i]);

                if (currRomanNumeral >= TryGetNumberValue(romanNumeralStr[i + 1]))
                {
                    result += currRomanNumeral;
                } else
                {
                    result -= currRomanNumeral;
                }
            }
            result += TryGetNumberValue(romanNumeralStr[^1]);

            if (result > 3999)
                throw new InvalidRomanNumeralException("The roman numeral " + romanNumeralStr + " is above max value with the value " + result);

            return result;
        }

        private int TryGetNumberValue(char numeral)
        {
            if (!_romanNumbersDic.TryGetValue(numeral, out int result))
            {
                throw new InvalidRomanNumeralException("The letter " + numeral + " is not a valid roman letter");
            }
            return result;
        }
    }
}