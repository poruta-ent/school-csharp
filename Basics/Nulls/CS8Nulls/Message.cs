using System;
using System.Collections.Generic;
using System.Text;

namespace CS8Nulls
{
    public class Message
    {
        public string? From { get; set; }
        public string Text { get; set; } = string.Empty;
        public string? ConvertFromToUpper() => From?.ToUpperInvariant();
    }
}
