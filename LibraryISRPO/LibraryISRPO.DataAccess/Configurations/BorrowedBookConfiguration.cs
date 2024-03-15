using LibraryISRPO.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace LibraryISRPO.DataAccess.Configurations { 
    public class BorrowedBookConfiguration : IEntityTypeConfiguration<BorrowedBookEntity>
    {
        public void Configure(EntityTypeBuilder<BorrowedBookEntity> builder)
        {
            builder.HasKey(bb => new { bb.BookId, bb.VisitorId });

            builder.Property(bb => bb.BorrowedDate)
                .IsRequired();

            builder.HasOne(bb => bb.Book)
                .WithMany(b => b.BorrowedBook) // Исправленное свойство
                .HasForeignKey(bb => bb.BookId);

            builder.HasOne(bb => bb.Visitor)
                .WithMany(v => v.BorrowedBook) // Исправленное свойство
                .HasForeignKey(bb => bb.VisitorId);
        }
    }
}
