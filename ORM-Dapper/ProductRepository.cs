using System.Data;
using Dapper;

namespace ORM_Dapper;

public class ProductRepository : IProductRepository
{
    private readonly IDbConnection _conn;
    
    public ProductRepository(IDbConnection conn)
    {
        _conn = conn;
    }
    public void CreateProduct(string name, double price, int categoryId)
    {
        _conn.Execute("INSERT INTO products (Name, Price, CategoryID) VALUES (@name, @price, @categoryID);", new {name, price, categoryId});
    }
    
    //Bonus
    public void UpdateProduct(int productId, string updateName)
    {
        _conn.Execute("UPDATE products SET Name = @updateName WHERE ProductID = @productID;", new {productId, updateName});
    }

    //Double Bonus
    public void DeleteProduct(int productId)
    {
        _conn.Execute("DELETE FROM reviews WHERE ProductID = @productID;", new {productId});
        
        _conn.Execute("DELETE FROM sales WHERE ProductID = @productID;", new {productId});
        
        _conn.Execute("DELETE FROM products WHERE ProductID = @productID;", new {productId});
    }
    
    public IEnumerable<Product> GetAllProducts()
    {
       return _conn.Query<Product>("SELECT * FROM products;");
    }
    
}