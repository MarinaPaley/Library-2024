﻿// <copyright file="AuthorTests.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>

namespace DomainTest
{
    using System;
    using System.Collections.Generic;
    using Domain;
    using NUnit.Framework;

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
        public void Ctor_NullPatronicName_DoesNotThrow(string? patronicName)
        {
            var dateBirth = new DateOnly(1828, 09, 28);
            var dateDeath = new DateOnly(1910, 10, 20);
            Assert.DoesNotThrow(() =>
            _ = new Author("Толстой", "Лев", patronicName, dateBirth, dateDeath));
        }

        /// <summary>
        /// Тест на конструктор с неизвестными датами жизни.
        /// </summary>
        /// <param name="dateBirth"> Дата рождения. </param>
        /// <param name="dateDeath"> Дата смерти. </param>
        [TestCaseSource(nameof(ValidDateData))]
        public void Ctor_DateLiveNull_DoesNotThrow(DateOnly? dateBirth, DateOnly? dateDeath)
        {
            Assert.DoesNotThrow(() =>
                _ = new Author("Толстой", "Лев", "Николаевич", dateBirth, dateDeath));
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
            var dateDeath = new DateOnly(1910, 10, 20);
            Assert.Throws<ArgumentNullException>(
                () => _ = new Author(familyName, firstName, null, dateBirth, dateDeath));
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Equals_ValidDataDifferentName_Success()
        {
            // Arrange
            var author1 = new Author("Толстой", "Лев", "Николаевич", new DateOnly(1828, 09, 28), null);
            var author2 = new Author("Пушкин", "Александр", "Сергеевич", new DateOnly(1799, 06, 06), null);

            // Act & Assert
            Assert.That(author1, Is.Not.EqualTo(author2));
        }

        /// <summary>
        /// 
        /// </summary>
        [TestCaseSource(nameof(DataForNotEqual))]
        public void Equals_SimilarAuthorsDifferentDates_NotEqual(
            DateOnly? dateBirth1,
            DateOnly? dateDeath1,
            DateOnly? dateBirth2,
            DateOnly? dateDeath2)
        {
            // Arrange
            var author1 = new Author("Толстой", "Лев", "Николаевич", dateBirth1, dateDeath1);
            var author2 = new Author("Толстой", "Лев", "Николаевич", dateBirth2, dateDeath2);

            // Act & Assert
            Assert.That(author1, Is.Not.EqualTo(author2));
        }

        [TestCase("Николаевич", null)]
        [TestCase(null, "Николаевич")]
        [TestCase("Сергеевич", "Николаевич")]
        public void Equals_ValidDataDifferentPatronicName_Success(string? name1, string? name2)
        {
            // Arrange
            var author1 = new Author("Толстой", "Лев", name1, null, null);
            var author2 = new Author("Толстой", "Лев", name2, null, null);

            // Act & Assert
            Assert.That(author1, Is.Not.EqualTo(author2));
        }

        private static IEnumerable<TestCaseData> ValidDateData()
        {
            yield return new TestCaseData(new DateOnly(1828, 09, 28), null);
            yield return new TestCaseData(null, new DateOnly(1910, 10, 20));
            yield return new TestCaseData(null, null);
        }

        private static IEnumerable<TestCaseData> DataForNotEqual()
        {
            yield return new TestCaseData(new DateOnly(1828, 09, 28), null, null, null);
            yield return new TestCaseData(null, new DateOnly(1910, 10, 20), null, null);
            yield return new TestCaseData(null, null, new DateOnly(1828, 09, 28), null);
            yield return new TestCaseData(null, null, null, new DateOnly(1910, 10, 20));
            yield return new TestCaseData(new DateOnly(1828, 09, 28), null, new DateOnly(1829, 09, 28), null);
            yield return new TestCaseData(null, new DateOnly(1910, 10, 20), null, new DateOnly(1911, 10, 20));
        }
    }
}
