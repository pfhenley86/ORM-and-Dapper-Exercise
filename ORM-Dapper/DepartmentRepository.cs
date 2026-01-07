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

    public IEnumerable<Department> GetALLDepartments()
    {
        return _conn.Query<Department>("SELECT * FROM departments");
    }
    
    public void InsertDepartment(string name)
    {
        _conn.Execute("INSERT INTO departments (name) VALUES (@name);", new {name = name});
    }
}