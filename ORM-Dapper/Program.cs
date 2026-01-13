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

var productRepo = new ProductRepository(conn);
var departmentRepo = new DepartmentRepository(conn);
var products = productRepo.GetAllProducts();
var departments = departmentRepo.GetALLDepartments();

//productRepo.CreateProduct("newstuff", 20, 1);

//productRepo.UpdateProduct(940,"oldstuff");

//productRepo.DeleteProduct(942);

foreach (var prod in products)
{
    Console.WriteLine($"Product ID: {prod.ProductID}, Name: {prod.Name}, Price: {prod.Price}");
}

//departmentRepo.InsertDepartment("golf");

//departmentRepo.UpdateDepartment(8,"pets");

departmentRepo.DeleteDepartment(8);

foreach(var dep in departments){
    Console.WriteLine($"Department ID: {dep.DepartmentID}, Name: {dep.Name}");
}
