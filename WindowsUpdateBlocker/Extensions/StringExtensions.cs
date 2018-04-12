namespace WindowsUpdateBlocker.Extensions
{
    public static class StringExtensions
    {
        public static string Indent(this string value, string indent = "    ")
        {
            return value.Replace("\n", "\n" + indent);
        }
    }
}