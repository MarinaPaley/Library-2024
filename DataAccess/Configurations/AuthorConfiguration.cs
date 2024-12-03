// <copyright file="AuthorConfiguration.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>

namespace DataAccess.Configurations
{
    using Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Конфигурация правил отображения сущности (<see cref="Author"/>) в таблицу БД.
    /// </summary>
    public sealed class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            _ = builder.HasKey(author => author.Id);

            _ = builder.Property(author => author.FamilyName)
                .HasMaxLength(100)
                .IsRequired();

            _ = builder.Property(author => author.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            _ = builder.Property(author => author.PatronicName)
                .HasMaxLength(100)
                .IsRequired(false);

            _ = builder.Property(author => author.DateBirth)
                .IsRequired(false);

            _ = builder.Property(author => author.DateDeath)
                .IsRequired(false);

            _ = builder.HasMany(author => author.Books)
                .WithMany(book => book.Authors);
        }
    }
}
