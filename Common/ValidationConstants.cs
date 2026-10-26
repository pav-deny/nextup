namespace NextUp.Common
{
    public static class ValidationConstants
    {
        public static class Category
        {
            public const int MaxNameLength = 50;
            public const int MaxColorHexLength = 7; //Includes #
            public const string HexCodeRegEx = "^#[0-9A-Fa-f]{6}$"; //Takes input like #BC8910 -> # + a hexadecimal number (upper AND lower case)
            public const string HexCodeErrMsg = "Use a hex color like #FF8C5A.";
        }
    }
}
