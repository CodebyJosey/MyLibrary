// Copyright (c) 2025 Josey van Aarsen
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
namespace CodeByJosey.MyLibrary.Data.Repositories;

using CodeByJosey.MyLibrary.Data.Models;

public interface IProductRepository
{
    Product GetProductById(int id);
    IEnumerable<Product> GetAllProducts();
    void AddProduct(Product product);
    void UpdateProduct(Product product);
    void DeleteProduct(Product product);
}