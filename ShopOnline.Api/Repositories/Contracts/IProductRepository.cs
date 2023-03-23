using ShopOnline.Api.Entities;

namespace ShopOnline.Api.Repositories.Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetItems();
        Task<IEnumerable<ProductCategory>> GetGategories();
        Task<Product> GetItem(int id);
        Task<ProductCategory> GetGategory(int id);

    }
}
