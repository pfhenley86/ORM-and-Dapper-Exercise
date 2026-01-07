using System.Data;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using ORM_Dapper;

var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

string connString = config.GetConnectionString("DefaultConnection");
IDbConnection conn = new MySqlConnection(connString);

var repo = new ProductRepository(conn);
var products = repo.GetAllProducts();

//repo.CreateProduct("newstuff", 20, 1);

//repo.UpdateProduct(940,"oldstuff");

//repo.DeleteProduct(942);

foreach (var prod in products)
{
    Console.WriteLine($"Product ID: {prod.ProductID}, Name: {prod.Name}, Price: {prod.Price}");
}
