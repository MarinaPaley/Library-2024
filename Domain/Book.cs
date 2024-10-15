// <copyright file="Book.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>

namespace Domain
{
    using System.Collections.Generic;
    using Staff;

    /// <summary>
    /// Класс Книга.
    /// </summary>
    public sealed class Book : IEquatable<Book>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Book"/>.
        /// </summary>
        /// <param name="title"> Название.</param>
        /// <param name="pages"> Количество страниц. </param>
        /// <param name="ibsn"> Код IBSN. </param>
        /// <param name="shelf"> Полка. </param>
        /// <param name="authors"> Авторы. </param>
        /// <exception cref="ArgumentNullException">Если название книги или код <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"> Если количество страниц меньше или равно нулю.</exception>
        /// <exception cref="ArgumentOutOfRangeException"> Если полка <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"> Если авторы <see langword="null"/>.</exception>
        public Book(string title, int pages, string ibsn, Shelf shelf, ISet<Author> authors)
        {
            this.Authors = authors ?? throw new ArgumentNullException(nameof(authors));

            this.Title = title.TrimOrNull() ?? throw new ArgumentNullException(nameof(title));
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(pages);

            this.Pages = pages;
            this.IBSN = ibsn.TrimOrNull() ?? throw new ArgumentNullException(nameof(ibsn));
            this.Id = Guid.NewGuid();
            this.Shelf = shelf ?? throw new ArgumentNullException(nameof(shelf));

            _ = shelf.AddBook(this);

            foreach (var author in authors)
            {
                _ = author.Books.Add(this);
            }
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Book"/>.
        /// </summary>
        /// <param name="title"> Название.</param>
        /// <param name="pages"> Количество страниц. </param>
        /// <param name="ibsn"> Код IBSN. </param>
        /// <param name="shelf"> Полка. </param>
        /// <param name="authors"> Авторы. </param>
        /// <exception cref="ArgumentNullException">Если название книги или код <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"> Если количество страниц меньше или равно нулю.</exception>
        /// <exception cref="ArgumentOutOfRangeException"> Если полка <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"> Если авторы <see langword="null"/>.</exception>
        public Book(string title, int pages, string ibsn, Shelf shelf, params Author[] authors)
            : this(title, pages, ibsn, shelf, new HashSet<Author>(authors))
        {
        }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Название.
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Количество страниц.
        /// </summary>
        public int Pages { get; }

        /// <summary>
        /// Код IBSN.
        /// </summary>
        public string IBSN { get; }

        /// <summary>
        /// Полка.
        /// </summary>
        public Shelf Shelf { get; set; }

        /// <summary>
        /// Авторы.
        /// </summary>
        public ISet<Author> Authors { get; set; } = new HashSet<Author>();

        /// <inheritdoc/>
        public bool Equals(Book? other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (this.Title == other.Title)
            {
                return true;
            }

            return false;
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            return this.Equals(obj as Book);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return this.Title.GetHashCode();
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return this.Title;
        }
    }
}
