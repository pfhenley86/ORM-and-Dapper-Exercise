namespace ORM_Dapper;

public interface IDepartmentRepository
{
    IEnumerable<Department> GetAllDepartments();
    
    void CreateDepartment(string name);
    
    void UpdateDepartment(int departmentId, string updateName);
    
    void DeleteDepartment(int departmentId);
}