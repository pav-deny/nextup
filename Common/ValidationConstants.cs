namespace NextUp.Common
{
    public static class ValidationConstants
    {
        public const int MinCategoryId = 1;
        public const int MaxCategoryId = int.MaxValue;
        public const string CategoryIdErrMsg = "Please select a valid category";
        public const int GlobalCategoryId = 1;

        public static class CategoryConstants
        {
            public const int MaxNameLength = 50;
            public const int MaxColorHexLength = 7; //Includes # (6 color-hex characters + # = 7)
            public const string HexCodeRegEx = "^#[0-9A-Fa-f]{6}$"; //Takes input like #BC8910 -> # + a hexadecimal number (upper AND lower case)
            public const string HexCodeErrMsg = "Use a hex color like #FF8C5A.";
        }

        public static class TagConstants
        {
            public const int MaxNameLength = 50;
        }

        public static class TaskConstants
        {
            public const int MaxTitleLength = 100;
            public const int MaxNotesLength = 500;
        }
    }
}
