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
    /// Тесты для класса <see cref="Domain.Book">.
    /// </summary>.
    public class BookTests
    {
        [Test]
        public void Ctor_NullTitle_ExpectedANE()
        {
            Assert.Throws<ArgumentNullException>(() => _ = new Book(null!, 100, "1"));
        }

        [Test]
        public void Ctor_NullISBN_ExpectedANE()
        {
            Assert.Throws<ArgumentNullException>(() => _ = new Book("Тестовое название", 100, null!));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void Ctor_NegativePages_ExpectedAOUR(int pages)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = new Book("Тестовое название", pages, "1"));
        }
    }
}
