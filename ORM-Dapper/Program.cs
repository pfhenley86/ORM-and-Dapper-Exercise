using System.Data;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using ORM_Dapper;

var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

string? connString = config.GetConnectionString("DefaultConnection");
IDbConnection conn = new MySqlConnection(connString);

IProductRepository productRepo = new ProductRepository(conn);
IDepartmentRepository departmentRepo = new DepartmentRepository(conn);
var products = productRepo.GetAllProducts();
var departments = departmentRepo.GetAllDepartments();

//productRepo.CreateProduct("coolnewstuff", 32, 3);

//productRepo.UpdateProduct(943,"superoldstuff");

//productRepo.DeleteProduct(943);

foreach (var prod in products)
{
    Console.WriteLine($"Product ID: {prod.ProductID}, Name: {prod.Name}, Price: {prod.Price}");
}

//departmentRepo.CreateDepartment("golf");

//departmentRepo.UpdateDepartment(9,"meats");

//departmentRepo.DeleteDepartment(9);

foreach(var dep in departments){
    Console.WriteLine($"Department ID: {dep.DepartmentID}, Name: {dep.Name}");
}
