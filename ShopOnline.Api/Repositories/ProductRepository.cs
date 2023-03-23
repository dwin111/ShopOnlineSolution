using Microsoft.EntityFrameworkCore;
using ShopOnline.Api.Data;
using ShopOnline.Api.Entities;
using ShopOnline.Api.Repositories.Contracts;

namespace ShopOnline.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopOnlineDbContext _shopOnlineDbContext;

        public ProductRepository(ShopOnlineDbContext shopOnlineDbContext)
        {
            _shopOnlineDbContext = shopOnlineDbContext;
        }
        public async Task<ProductCategory> GetGategory(int id)
        {
            var category = await _shopOnlineDbContext.ProductCategories.SingleOrDefaultAsync(pc => pc.Id == id);
            return category;
        }

        public async Task<IEnumerable<ProductCategory>> GetGategories()
        {
            var categories = await _shopOnlineDbContext.ProductCategories.ToListAsync();
            return categories;
        }

        public async Task<Product> GetItem(int id)
        {
            var product = await _shopOnlineDbContext.Products.FirstOrDefaultAsync(pd => pd.Id == id);
            return product;
        }

        public async Task<IEnumerable<Product>> GetItems()
        {
            var products = await _shopOnlineDbContext.Products.ToListAsync();
            return products;
        }
    }
}
