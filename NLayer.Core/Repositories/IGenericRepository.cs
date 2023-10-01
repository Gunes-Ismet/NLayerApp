using System.Linq.Expressions;

namespace NLayer.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);

        IQueryable<T> GetAll();

        // List kullanmama sebebimiz
        // Methodun geri döndüreceği değeri List<T> türünde tanımladığımızda ilk önce DB'den veriyi belleğe alır daha sonra belirtilen şart ve koşulları uygular. IQueryable'da ise DB'den veriyi çekerken belirtilen şart ve koşulları uygular.
        IQueryable<T> Where(Expression<Func<T, bool>> expression);

        Task AddAsync(T entity);

        Task AddRangeAsync(IEnumerable<T> entities);

        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);

        void Update(T entity);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);
    }
}
