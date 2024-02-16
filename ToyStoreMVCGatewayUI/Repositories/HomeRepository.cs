using Humanizer.Localisation;
using Microsoft.EntityFrameworkCore;
using ToyStoreMVCGatewayUI.Data;
using ToyStoreMVCGatewayUI.Models;

namespace ToyStoreMVCGatewayUI.Repositories
{ 
        public class HomeRepository : IHomeRepository
        {
            private readonly ApplicationDbContext _db;

            public HomeRepository(ApplicationDbContext db)
            {
                _db = db;
            }

            public async Task<IEnumerable<Category>> Categories()
            {
                return await _db.Categories.ToListAsync();
            }
            public async Task<IEnumerable<Product>> GetProducts(string sTerm = "", int categoryId = 0)
            {
                sTerm = sTerm.ToLower();
                IEnumerable<Product> products = await (from product in _db.Products
                                                       join category in _db.Categories
                                                       on product.CategoryId equals categoryId
                                                       where string.IsNullOrWhiteSpace(sTerm) || (product != null && product.ProductName.ToLower().StartsWith(sTerm))
                                                       select new Product
                                                       {
                                                           ProductId = product.ProductId,
                                                           Image = product.Image,
                                                           ProductName = product.ProductName,
                                                           ProductDescription = product.ProductDescription,
                                                           Rating = product.Rating,
                                                           CategoryId = product.CategoryId,
                                                           Price = product.Price,
                                                           CategoryName = product.CategoryName
                                                       }
                             ).ToListAsync();
                if (categoryId > 0)
                {

                    products = products.Where(a => a.CategoryId == categoryId).ToList();
                }
                return products;

            }
        }
    }
