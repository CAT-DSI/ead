namespace EAD.Data.Structures
{
    public struct UnicodeValue
    {
        public UnicodeValue(char value, char unicode)
        {
            Unicode = unicode.ToString();
            Value = value.ToString();
        }

        public UnicodeValue(string value, string unicode)
        {
            Unicode = unicode;
            Value = value;
        }

        public string Unicode { get; set; }

        public string Value { get; set; }
    }
}