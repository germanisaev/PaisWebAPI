using EmployeeWebApi.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EmployeeWebApi;

public class EmployeeService: IEmployeeService
{
    private readonly DbContextClass _dbContext;

        public EmployeeService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> AddEmployeeAsync(Employees employee)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@FirstName", employee.FirstName));
            parameter.Add(new SqlParameter("@LastName", employee.LastName));
            parameter.Add(new SqlParameter("@RoleCompany", employee.RoleCompany));
            parameter.Add(new SqlParameter("@DepartmentId", employee.DepartmentId));
            parameter.Add(new SqlParameter("@AgeDate", employee.AgeDate));
            parameter.Add(new SqlParameter("@CarOwner", employee.CarOwner));
            parameter.Add(new SqlParameter("@UserName", employee.UserName));

            var result = await Task.Run(() =>  _dbContext.Database
           .ExecuteSqlRawAsync(@"exec AddNewEmployee @FirstName, @LastName, @RoleCompany, @DepartmentId, @AgeDate, @CarOwner, @UserName", parameter.ToArray()));

            return result;
        }

        public async Task<int> DeleteEmployeeAsync(int EmployeeId)
        {
            return await Task.Run(() => _dbContext.Database.ExecuteSqlInterpolatedAsync($"DeleteEmployeeByID {EmployeeId}"));
        }

        public async Task<IEnumerable<Employees>> GetEmployeeByIdAsync(int EmployeeId)
        {
            var param = new SqlParameter("@EmployeeId", EmployeeId);

            var employeeDetails = await Task.Run(() => _dbContext.Employees
                            .FromSqlRaw(@"exec GetEmployeeByID @EmployeeId", param).ToListAsync());

            return employeeDetails;
        }

        public async Task<List<Employees>> GetEmployeeListAsync()
        {
            return await _dbContext.Employees
                .FromSqlRaw<Employees>("GetEmployeeList")
                .ToListAsync();
        }

        public async Task<int> UpdateEmployeeAsync(Employees employee)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@EmployeeId", employee.EmployeeId));
            parameter.Add(new SqlParameter("@FirstName", employee.FirstName));
            parameter.Add(new SqlParameter("@LastName", employee.LastName));
            parameter.Add(new SqlParameter("@RoleCompany", employee.RoleCompany));
            parameter.Add(new SqlParameter("@DepartmentId", employee.DepartmentId));
            parameter.Add(new SqlParameter("@AgeDate", employee.AgeDate));
            parameter.Add(new SqlParameter("@CarOwner", employee.CarOwner));
            parameter.Add(new SqlParameter("@UserName", employee.UserName));

            var result = await Task.Run(() => _dbContext.Database
            .ExecuteSqlRawAsync(@"exec UpdateEmployee @EmployeeId, @FirstName, @LastName, @RoleCompany, @DepartmentId, @AgeDate, @CarOwner, @UserName", parameter.ToArray()));
            return result;
        }
}
