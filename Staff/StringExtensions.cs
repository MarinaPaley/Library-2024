// <copyright file="StringExtensions.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>

namespace Staff
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string? value) => string.IsNullOrEmpty(value);

        public static string? TrimOrNull(this string value)
        {
            var trimmed = value?.Trim();
            return trimmed.IsNullOrEmpty()
                 ? null
                 : trimmed;
        }
    }
}
