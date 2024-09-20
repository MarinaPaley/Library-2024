// <copyright file="AuthorTests.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>

namespace DomainTest
{
    using System;
    using System.Collections.Generic;
    using Domain;

    /// <summary>
    /// Тесты для класса <see cref="Domain.Author">.
    /// </summary>.
    public class AuthorTests
    {
        /// <summary>
        /// Тест на конструктор с правильными параметрами.
        /// </summary>
        /// <param name="patronicName"> Отчество.</param>
        [TestCase("Николаевич")]
        [TestCase(null)]
        public void Ctor_ValidData_DoesNotThrow(string patronicName)
        {
            var dateBirth = new DateOnly(1828, 09, 28);
            Assert.DoesNotThrow(() =>
            _ = new Author("Толстой", "Лев", patronicName, dateBirth));
        }

        /// <summary>
        /// Тест на конструктор с <see langword=""="null"/> значениями.
        /// </summary>
        /// <param name="familyName"> Фамилия.</param>
        /// <param name="firstName"> Имя.</param>
        [TestCase(null, "")]
        [TestCase("", null)]
        public void Ctor_WrongData_ExpectedException(string familyName, string firstName)
        {
            var dateBirth = new DateOnly(1828, 09, 28);
            Assert.Throws<ArgumentNullException>(
                () => _ = new Author(familyName, firstName, null, dateBirth));
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Equals_ValidData_Success()
        {
            // Arrange
            var author1 = new Author("Толстой", "Лев", "Николаевич", new DateOnly(1828, 09, 28));
            var author2 = new Author("Пушкин", "Александр", "Сергеевич", new DateOnly(1799, 06, 06);

            // Act & Assert
            Assert.That(author1.Equals(author2), Is.False);
        }
    }
}
