using Microsoft.AspNetCore.Mvc;

namespace EmployeeWebApi;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController: ControllerBase
{
    private readonly IEmployeeService _service;
    private readonly ILogger<EmployeeController> _logger;

    public EmployeeController(ILogger<EmployeeController> logger, IEmployeeService service)
    {
        this._service = service;
        _logger = logger;
    }

    [HttpGet("getemployeelist")]
        public async Task<List<Employees>> GetEmployeeListAsync()
        {
            try
            {
                return await _service.GetEmployeeListAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "EmployeeService.GetEmployeeListAsync encountered an exception.");
                throw;
            }
        }

        [HttpGet("getemployeebyid")]
        public async Task<IEnumerable<Employees>> GetEmployeeByIdAsync(int Id)
        {
            try
            {
                var response = await _service.GetEmployeeByIdAsync(Id);

                if(response == null)
                {
                    return null;
                }

                return response;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "EmployeeService.GetEmployeeByIdAsync encountered an exception.");
                throw;
            }
        }

        [HttpPost("addemployee")]
        public async Task<IActionResult> AddEmployeeAsync(Employees employee)
        {
            if(employee == null)
            {
                return BadRequest();
            }

            try
            {
                var response = await _service.AddEmployeeAsync(employee);

                return Ok(response);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "EmployeeService.AddEmployeeAsync encountered an exception.");
                throw;
            }
        }

        [HttpPut("updateemployee")]
        public async Task<IActionResult> UpdateEmployeeAsync(Employees employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }

            try
            {
                var result =  await _service.UpdateEmployeeAsync(employee);
                return Ok(result);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "EmployeeService.UpdateEmployeeAsync encountered an exception.");
                throw;
            }
        }

        [HttpDelete("deleteemployee")]
        public async Task<int> DeleteEmployeeAsync(int Id)
        {
            try
            {
                var response = await _service.DeleteEmployeeAsync(Id);
                return response;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "EmployeeService.DeleteEmployeeAsync encountered an exception.");
                throw;
            }
        }
}
