using ShopOnline.Api.Entities;
using ShopOnline.Models.Dtos;

namespace ShopOnline.Api.Extensions
{
    public static class DtoConversions
    {

        public static IEnumerable<ProductDto> ConvertToDto(this IEnumerable<Product> products,
                                                            IEnumerable<ProductCategory> productCategories)
        {
            return (from product in products
                    join productCategory in productCategories
                    on product.CategoryId equals productCategory.Id
                    select new ProductDto
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        ImageURL = product.ImageURL,
                        Qty = product.Qty,
                        CategoryId = product.CategoryId,
                        CategoryName = productCategory.Name,
                        Price = product.Price,
                        
                        
                    });
        }
        public static ProductDto ConvertToDto(this Product product, ProductCategory productCategories)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                ImageURL = product.ImageURL,
                Qty = product.Qty,
                CategoryId = product.CategoryId,
                CategoryName = productCategories.Name,
                Price = product.Price
            };
        }

        public static IEnumerable<CartItemDto> ConvertToDto(this IEnumerable<CartItem> cartItems,
                                                               IEnumerable<Product> products)
        {
            return (from cartItem in cartItems
                    join product in products
                    on cartItem.ProductId equals product.Id
                    select new CartItemDto
                    {
                        Id = cartItem.Id,
                        CartId = cartItem.CartId,
                        ProductId = product.Id,
                        ProductName = product.Name,
                        Price= product.Price,   
                        ProductDescription = product.Description,
                        ProductImageURL = product.ImageURL,
                        Qty = product.Qty,
                        TotalPrice = product.Price * product.Qty
                    }).ToList();
        }
        public static CartItemDto ConvertToDto(this CartItem cartItem,Product product)
        {
            return new CartItemDto
                    {
                        Id = cartItem.Id,
                        CartId = cartItem.CartId,
                        ProductId = product.Id,
                        ProductName = product.Name,
                        Price = product.Price,
                        ProductDescription = product.Description,
                        ProductImageURL = product.ImageURL,
                        Qty = product.Qty,
                        TotalPrice = product.Price * product.Qty
                    };
        }


    }
}
