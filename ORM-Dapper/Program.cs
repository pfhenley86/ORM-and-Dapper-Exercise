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

var departmentRepo = new DepartmentRepository(conn);

//departmentRepo.InsertDepartment("CSharp-65");

var departments = departmentRepo.GetALLDepartments();

foreach (var dep in departments)
{
    Console.WriteLine($"Name: {dep.Name} | ID: {dep.DepartmentID}");
}
