using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models;
using System.Reflection;

namespace NLayer.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //var p = new Product() { ProductFeature = new ProductFeature() }; // Gerçek dünyada(Base Practice'te) ProductFeature'un Product üzerinden işlem görmesi daha iyi. 
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductFeature> ProductFeatures { get; set; }


        public override int SaveChanges()
        {
            UpdateChangeTracker();
            return base.SaveChanges();
        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateChangeTracker();
            return base.SaveChangesAsync(cancellationToken);
        }

        public void UpdateChangeTracker()
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityReference)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            {
                                entityReference.CreatedDate = DateTime.Now;
                                break;
                            }
                        case EntityState.Modified:
                            {
                                Entry(entityReference).Property(x => x.CreatedDate).IsModified = false;
                                entityReference.UpdatedDate = DateTime.Now;
                                break;
                            }
                    }
                }
            }
        }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Custom property isimlendirmelerinde entity'lerimize attribute eklemek best practice açısından uygun değil. Bu yüzden belirtmemiz gereken özellikleri OnModelBuilder içerisinde vermemiz daha uygun olacaktır.

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); // IEntityTypeConfiguration interface'ini emplement eden sınıfları tarayıp otomatik kendi buluyor ve uyguluyor.


            // Aşağıdaki şekilde tek tek de girilebilir ama çok büyük projelerde yüzlerce satır kod yazılmasını gerektireceği için uygun değildir.

            //modelBuilder.ApplyConfiguration(new ProductFeatureConfiguration()); 

            modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature()
            {
                Id = 1,
                Color = "Kırmızı",
                Height = 100,
                Width = 200,
                ProductId = 1,
            },
            new ProductFeature
            {
                Id = 2,
                Color = "Mavi",
                Height = 300,
                Width = 500,
                ProductId = 2,
            });
            base.OnModelCreating(modelBuilder);
        }

    }
}
