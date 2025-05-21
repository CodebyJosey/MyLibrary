using MyLibrary.Data.Models;

namespace MyLibrary.Data.Repositories;

public interface IProductRepository
{
    Product GetProductById(int id);
    IEnumerable<Product> GetAllProducts();
    void AddProduct(Product product);
    void UpdateProduct(Product product);
    void DeleteProduct(Product product);
}