using System;

namespace HW_Attributes
{
    public sealed class SecretAttribute : Attribute
    {
        public string SecretSymbol { get; set; }

        public bool Status { get; set; }

        public SecretAttribute(string symbol)
        {
            SecretSymbol = symbol;
        }
    }
}
