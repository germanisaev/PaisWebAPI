namespace EmployeeWebApi;

public interface IEmployeeService
{
    public Task<List<Employees>> GetEmployeeListAsync();
    public Task<IEnumerable<Employees>> GetEmployeeByIdAsync(int Id);
    public Task<int> AddEmployeeAsync(Employees employee);
    public Task<int> UpdateEmployeeAsync(Employees employee);
    public Task<int> DeleteEmployeeAsync(int Id);
}
