// <copyright file="ShelfTests.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>

namespace DomainTest
{
    using System;
    using Domain;

    /// <summary>
    /// Тесты на полку <see cref="Domain.Author"/>.
    /// </summary>
    public class ShelfTests
    {
        /// <summary>
        /// Тест на конструктор с правильными параметрами.
        /// </summary>
        [Test]
        public void Ctor_ValidData_Success()
        {
            Assert.DoesNotThrow(() => _ = new Shelf("Полка 1"));
        }

        /// <summary>
        /// Тест на конструктор, вызывающий исключение.
        /// </summary>
        [Test]
        public void Ctor_NullData_ExpectedException()
        {
            Assert.Throws<ArgumentNullException>(() => _ = new Shelf(null!));
        }

        /// <summary>
        /// Тест на метод <see cref="Domain.Shelf.Equals(Shelf?)"/>.
        /// </summary>
        /// <param name="name1"> Название первой полки. </param>
        /// <param name="name2"> Название второй полки. </param>
        /// <param name="expected"> Ожидаемое Значение для сравнения.</param>
        [TestCase("1", "1", true)]
        [TestCase("1", "2", false)]
        public void Equals_ValidData_Success(string name1, string name2, bool expected)
        {
            // arrange
            var shelf1 = new Shelf(name1);
            var shelf2 = new Shelf(name2);

            // act
            var actual = shelf1.Equals(shelf2);

            // assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Тест на <see cref="Domain.Shelf.ToString()"/>.
        /// </summary>
        [Test]
        public void ToString_ValidData_Success()
        {
            // arrange
            const string expected = "Название полки Полка 1";
            var shelf = new Shelf("Полка 1");

            // act
            var actual = shelf.ToString();

            // assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}