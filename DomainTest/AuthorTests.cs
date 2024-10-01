// <copyright file="AuthorTests.cs" company="Васильева М.А.">
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
        public void Equals_ValidData_Success()
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
        [Test]
        public void Equals_SimilarAuthors_NotEqual()
        {
            // Arrange
            var author1 = new Author("Толстой", "Лев", "Николаевич", new DateOnly(1828, 09, 28), null);
            var author2 = new Author("Толстой", "Лев", null, new DateOnly(1828, 09, 28), null);

            // Act & Assert
            Assert.That(author1, Is.Not.EqualTo(author2));
        }

        private static IEnumerable<TestCaseData> ValidDateData()
        {
            yield return new TestCaseData(new DateOnly(1828, 09, 28), null);
            yield return new TestCaseData(null, new DateOnly(1910, 10, 20));
            yield return new TestCaseData(null, null);
        }
    }
}
