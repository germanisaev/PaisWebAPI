
using EmployeeWebApi.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeWebApi;

public class RoleService : IRoleService
{
    private readonly DbContextClass _dbContext;

    public RoleService(DbContextClass dbContext)
    {
            _dbContext = dbContext;
    }
    public async Task<List<RoleCompanies>> GetRoleListAsync()
    {
        return await _dbContext.RoleCompanies
                .FromSqlRaw<RoleCompanies>("GetRoleList")
                .ToListAsync();
    }
}
