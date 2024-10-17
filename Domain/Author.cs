// <copyright file="Author.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>

namespace Domain
{
    using System;
    using System.Collections.Generic;
    using Staff;

    /// <summary>
    /// Класс Автор.
    /// </summary>
    public sealed class Author : IEquatable<Author>
    {
        private Author() { }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Author"/>.
        /// </summary>
        /// <param name="familyName"> Фамилия.</param>
        /// <param name="firstName"> Имя. </param>
        /// <param name="patronicName"> Отчество. </param>
        /// <param name="dateBirth"> Дата рождения. </param>
        /// <param name="dateDeath"> Дата смерти. </param>
        /// <exception cref="ArgumentNullException">
        /// Если имя или фамилия <see langword="null"/>.
        /// </exception>
        public Author(
            string familyName,
            string firstName,
            string? patronicName = null,
            DateOnly? dateBirth = null,
            DateOnly? dateDeath = null)
        {
            this.Id = Guid.NewGuid();
            this.FamilyName = familyName.TrimOrNull() ?? throw new ArgumentNullException(nameof(familyName));
            this.FirstName = firstName.TrimOrNull() ?? throw new ArgumentNullException(nameof(firstName));
            this.PatronicName = patronicName?.TrimOrNull();
            this.DateBirth = dateBirth;
            this.DateDeath = dateDeath;
        }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string FamilyName { get; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string FirstName { get; }

        /// <summary>
        /// Отчество.
        /// </summary>
        public string? PatronicName { get; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateOnly? DateBirth { get; }

        /// <summary>
        /// Дата смерти.
        /// </summary>
        public DateOnly? DateDeath { get; }

        /// <summary>
        /// Книги автора.
        /// </summary>
        public ISet<Book> Books { get; set; } = new HashSet<Book>();

        /// <inheritdoc/>
        public bool Equals(Author? other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (this.FirstName != other.FirstName
                || this.FamilyName != other.FamilyName)
            {
                return false;
            }

            if (((this.PatronicName is null) && (other.PatronicName is not null))
                || ((this.PatronicName is not null) && (other.PatronicName is null)))
            {
                return false;
            }

            if (this.PatronicName != other.PatronicName)
                {
                    return false;
                }

            if (((this.DateBirth is not null) && (other.DateBirth is null))
                || ((this.DateBirth is null) && (other.DateBirth is not null)))
            {
                return false;
            }

            if (this.DateBirth != other.DateBirth)
            {
                return false;
            }

            if (((this.DateDeath is not null) && (other.DateDeath is null))
                || ((this.DateDeath is null) && (other.DateDeath is not null)))
            {
                return false;
            }

            if (this.DateDeath != other.DateDeath)
            {
                return false;
            }

            return true;
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            return this.Equals(obj as Author);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = this.FamilyName.GetHashCode()
                * this.FirstName.GetHashCode();

            if (this.PatronicName is not null)
            {
                hashCode *= this.PatronicName.GetHashCode();
            }

            if (this.DateBirth is not null)
            {
                hashCode *= this.DateBirth.GetHashCode();
            }

            if (this.DateDeath is not null)
            {
                hashCode *= this.DateDeath.GetHashCode();
            }

            return hashCode;
        }

        /// <inheritdoc/>
        public override string ToString() =>
            (this.PatronicName is null)
            ? $"{this.FamilyName} {this.FirstName} {this.PatronicName}"
            : $"{this.FamilyName} {this.FirstName}";
    }
}
