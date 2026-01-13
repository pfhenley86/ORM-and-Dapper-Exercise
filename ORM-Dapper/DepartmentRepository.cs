using System.Data;
using Dapper;

namespace ORM_Dapper;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly IDbConnection _conn;

    public DepartmentRepository(IDbConnection conn)
    {
        _conn = conn;
    }

    public IEnumerable<Department> GetAllDepartments()
    {
        return _conn.Query<Department>("SELECT * FROM departments");
    }
    
    public void CreateDepartment(string name)
    {
        _conn.Execute("INSERT INTO departments (name) VALUES (@name);", new {name = name});
    }
    
    //Bonus
    public void UpdateDepartment(int departmentId, string updateName)
    {
        _conn.Execute("UPDATE departments SET Name = @updateName WHERE DepartmentID = @DepartmentID;", new { departmentID = departmentId, updateName});
    }
    
    public void DeleteDepartment(int departmentId)
    {
        _conn.Execute("DELETE FROM departments WHERE DepartmentID = @departmentID;", new {departmentId});
    }
}