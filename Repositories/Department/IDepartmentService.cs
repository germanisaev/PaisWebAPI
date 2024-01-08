namespace EmployeeWebApi;

public interface IDepartmentService
{
    public Task<List<Departments>> GetDepartmentListAsync();
}
