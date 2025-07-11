namespace EshopApp.Shared
{
    /// <summary>
    /// Provides common utility extension methods for use throughout the EshopApp.
    /// </summary>
    public static class CommonUtils
    {
        /// <summary>
        /// Returns the default value if the given Guid is empty; otherwise, returns the original Guid.
        /// </summary>
        /// <param name="guid">The Guid to check.</param>
        /// <param name="defaultValue">The default value to return if the Guid is empty.</param>
        /// <returns>The original Guid or the default value.</returns>
        public static Guid OrDefault(this Guid guid, Guid defaultValue)
        {
            return guid == Guid.Empty ? defaultValue : guid;
        }

        /// <summary>
        /// Determines whether the specified string is null, empty, or consists only of white-space characters.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <returns>True if the string is null, empty, or white-space; otherwise, false.</returns>
        public static bool IsNullOrEmpty(this string? value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// Truncates the string to the specified maximum length and appends ellipsis if necessary.
        /// </summary>
        /// <param name="text">The string to truncate.</param>
        /// <param name="maxLength">The maximum allowed length.</param>
        /// <returns>The truncated string with ellipsis if it exceeded the maximum length.</returns>
        public static string Truncate(this string text, int maxLength)
        {
            if (string.IsNullOrEmpty(text)) return string.Empty;
            return text.Length <= maxLength ? text : text.Substring(0, maxLength) + "...";
        }

        /// <summary>
        /// Formats the decimal amount as a currency string in Toman.
        /// </summary>
        /// <param name="amount">The amount to format.</param>
        /// <returns>The formatted currency string.</returns>
        public static string ToCurrency(this decimal amount)
        {
            return string.Format("{0:N0} تومان", amount);
        }
    }
}
