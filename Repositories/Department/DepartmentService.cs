
using EmployeeWebApi.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EmployeeWebApi;

public class DepartmentService : IDepartmentService
{
    private readonly DbContextClass _dbContext;

    public DepartmentService(DbContextClass dbContext)
    {
            _dbContext = dbContext;
    }
    
    public async Task<List<Departments>> GetDepartmentListAsync()
    {
        return await _dbContext.Departments
                .FromSqlRaw<Departments>("GetDepartmentList")
                .ToListAsync();
    }
}
