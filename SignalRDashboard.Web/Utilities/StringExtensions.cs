namespace SignalRDashboard.Web.Utilities
{
    public static class StringExtensions
    {
        public static string ToCamelCase(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }
            var firstChar = value[0];
            if (char.IsLower(firstChar))
            {
                return value;
            }
            firstChar = char.ToLowerInvariant(firstChar);
            return firstChar + value.Substring(1);
        }
    }
}