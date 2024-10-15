// <copyright file="BookTests.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>

namespace DomainTest
{
    using System;
    using System.Collections.Generic;
    using Domain;
    using NUnit.Framework;

    /// <summary>
    /// Тесты для класса <see cref="Domain.Book"/>.
    /// </summary>
    [TestFixture]
    public sealed class BookTests
    {
        private static readonly Shelf Shelf = new ("Полка");

        private static readonly ISet<Author> Authors = new HashSet<Author>() { new ("Толстой", "Лев"), };

        [Test]
        public void Ctor_NullTitle_ExpectedANE()
        {
            Assert.Throws<ArgumentNullException>(
                () => _ = new Book(null!, 100, "1", Shelf, Authors));
        }

        [Test]
        public void Ctor_NullISBN_ExpectedANE()
        {
            Assert.Throws<ArgumentNullException>(
                () => _ = new Book("Тестовое название", 100, null!, Shelf, Authors));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void Ctor_NegativePages_ExpectedAOUR(int pages)
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => _ = new Book("Тестовое название", pages, "1", Shelf, Authors));
        }
    }
}
