// <copyright file="BookConfiguration.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>

namespace DataAccess.Configurations
{
    using Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Конфигурация правил отображения сущности (<see cref="Book"/>) в таблицу БД.
    /// </summary>
    public sealed class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            _ = builder.HasKey(book => book.Id);

            _ = builder.Property(book => book.Title)
                .HasMaxLength(100)
                .IsRequired();

            _ = builder.Property(book => book.Pages)
                .IsRequired();

            _ = builder.Property(book => book.IBSN)
                .IsRequired(false);


            _ = builder.HasMany(book => book.Authors)
                .WithMany(author => author.Books);

            _ = builder.HasOne(book => book.Shelf)
                .WithMany(shelf => shelf.Books);
        }
    }
}
