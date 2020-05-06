using System;

namespace Duskland.Exceptions
{
    public class UnknownBodyPartException : ArgumentOutOfRangeException
    {
        public UnknownBodyPartException(string paramName, object actualValue, string message) : base(paramName, actualValue, message)
        {
        }
    }
}