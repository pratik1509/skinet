using System;
using Core.Entities;

namespace Core.Interfaces;

public interface IProductsRepository
{
    Task<IReadOnlyList<Product>> GetProductsAsync(string? brand, string? type, string? sort);
    Task<Product?> GetProductByIdAsync(int id);
    void  AddProduct(Product product);
    void UpdateProduct(Product product);
    void  DeleteProduct(Product product);
    bool ProductExist(int id);
    Task<bool> SaveChangesAsync();
    Task<IReadOnlyList<string>> GetBrandsAsync();
    Task<IReadOnlyList<string>> GetTypesAsync();
}
