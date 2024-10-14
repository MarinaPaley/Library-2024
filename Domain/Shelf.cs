// <copyright file="Shelf.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>

namespace Domain
{
    using Staff;

    /// <summary>
    /// Класс Полка.
    /// </summary>
    public sealed class Shelf : IEquatable<Shelf>
    {
        private string name;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Shelf"/>.
        /// </summary>
        /// <param name="name"> Название полки.</param>
        public Shelf(string name)
        {
            this.Id = Guid.NewGuid();
            this.Name = name.TrimOrNull() ?? throw new ArgumentNullException(nameof(name));
        }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Книги.
        /// </summary>
        public ISet<Book> Books { get; set; } = new HashSet<Book>();

        /// <summary>
        /// Добавить книгу на полку.
        /// </summary>
        /// <param name="book"> Книга. </param>
        /// <returns> Полку с книгами. </returns>
        public Shelf AddBook(Book book)
        {
            this.Books.Add(book);
            return this;
        }

        /// <summary>
        /// Название полки.
        /// </summary>
        /// <exception cref="ArgumentNullException">Если название <see langword="null"/>.</exception>
        public string Name
        {
            get => this.name;
            set
            {
                this.name = value.TrimOrNull() ?? throw new ArgumentNullException(nameof(value));
            }
        }

        /// <inheritdoc />
        public bool Equals(Shelf? other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.Name == other.Name;
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            return this.Equals(obj as Shelf);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        /// <inheritdoc cref="object.ToString()"/>
        public override string ToString() => $"Название полки {this.Name}";
    }
}
