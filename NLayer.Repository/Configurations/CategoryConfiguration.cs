using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;

namespace NLayer.Repository.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id); // Id'sini Primary Key Olarak belirttik.
            builder.Property(x => x.Id).UseIdentityColumn(); // Id'sinin bir bir artmasını belirttik.
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50); // Name property'sinin gerekli olduğunu ve Maksimum 50 karakter alabileceğini belirttik.

            builder.ToTable("Categories"); // Custom oalrak DB'de tablo ismini belirtiyoruz. Belirtmediğimiz zaman AppDbContext içinde DbSet<Category> property'sine verdiğimiz ismi kullanacaktır.

        }
    }
}
