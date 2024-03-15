using LibraryISRPO.Core.Models;
using LibraryISRPO.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace LibraryISRPO.DataAccess.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<BookEntity>
    {
        public void Configure(EntityTypeBuilder<BookEntity> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(Book.MAX_TITLE_LENGTH);

            builder.Property(b => b.Description)
                .IsRequired(false);

        }
    }
}
