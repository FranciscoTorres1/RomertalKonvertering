using System.Runtime.Serialization;

namespace RomertalKonvertering
{
    [Serializable]
    public class InvalidRomanNumeralException : Exception
    {
        public InvalidRomanNumeralException() { }
        public InvalidRomanNumeralException(string? message) : base(message) { }
        public InvalidRomanNumeralException(string? message, Exception? innerException) : base(message, innerException) { }
        protected InvalidRomanNumeralException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}