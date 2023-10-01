using NLayer.Core.Models;

namespace NLayer.Core.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        // asekron oluşturduğumuz methodların sonuna Async eklememiz gerekiyor. Bu Method ismi yanlış kullanıldı!!
        Task<List<Product>> GetProductsWithCategory();
    }
}
