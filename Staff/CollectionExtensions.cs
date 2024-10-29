// <copyright file="CollectionExtensions.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>

namespace Staff
{
    using System.Collections.Generic;

    /// <summary>
    /// Расширение для коллекций.
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// Метод расширения для <see cref="string.Join"/>.
        /// </summary>
        /// <param name="objects"> Коллекция объектов.</param>
        /// <returns> Строка.</returns>
        public static string Join<T>(
                this IEnumerable<T> objects,
                string separator = ", ",
                string defaultResult = "")
        => objects is null ? defaultResult : string.Join(separator, objects);
    }
}
