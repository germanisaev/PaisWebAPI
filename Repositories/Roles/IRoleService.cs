namespace EmployeeWebApi;

public interface IRoleService
{
    Task<List<RoleCompanies>> GetRoleListAsync();
}
