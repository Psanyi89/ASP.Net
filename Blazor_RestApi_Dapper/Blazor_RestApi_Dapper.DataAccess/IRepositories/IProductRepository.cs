using Blazor_RestApi_Dapper.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blazor_RestApi_Dapper.DataAccess.IRepositories
{
   public interface IProductRepository
    {
        Task<IEnumerable<Product>> Search(string name, int? quantity, decimal? price);
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(int productId);
        Task<Product> GetProductByName(string name);
        Task<Product> AddProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task<Product> DeleteProduct(int productId);
    }
}
