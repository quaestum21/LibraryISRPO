using LibraryISRPO.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace LibraryISRPO.DataAccess.Configurations
{
    public class VisitorConfiguration : IEntityTypeConfiguration<VisitorEntity>

    {
        public void Configure(EntityTypeBuilder<VisitorEntity> builder)
        {
            builder.HasKey(v => v.Id);

            builder.Property(v => v.Name)
                .IsRequired()
                .HasMaxLength(100); // Пример максимальной длины имени

            builder.Property(v => v.Email)
                .IsRequired();
        }
    }
}
