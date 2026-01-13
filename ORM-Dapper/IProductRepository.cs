namespace ORM_Dapper;

public interface IProductRepository
{
    IEnumerable<Product> GetAllProducts();
    
    void CreateProduct(string name, double price, int categoryId);
    
    void UpdateProduct(int productId, string updateName);
    
    void DeleteProduct(int productId);
}