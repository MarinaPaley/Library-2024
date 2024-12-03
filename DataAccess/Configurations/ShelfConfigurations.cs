// <copyright file="ShelfConfiguration.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>

namespace DataAccess.Configurations
{
    using Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Конфигурация правил отображения сущности (<see cref="Shelf"/>) в таблицу БД.
    /// </summary>
    public sealed class ShelfConfiguration : IEntityTypeConfiguration<Shelf>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Shelf> builder)
        {
            _ = builder.HasKey(shelf => shelf.Id);

            _ = builder.Property(shelf => shelf.Name)
                .HasMaxLength(100)
                .IsRequired();

            _ = builder.HasMany(shelf => shelf.Books)
                .WithOne(book => book.Shelf);
        }
    }
}
