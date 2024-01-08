using Microsoft.AspNetCore.Mvc;

namespace EmployeeWebApi;

[Route("api/[controller]")]
[ApiController]
public class DepartmentController: ControllerBase
{
    private readonly IDepartmentService _service;
    private readonly ILogger<DepartmentController> _logger;

    public DepartmentController(ILogger<DepartmentController> logger, IDepartmentService service)
    {
        this._service = service;
        _logger = logger;
    }

    [HttpGet("getdepartmentlist")]
    public async Task<List<Departments>> GetDepartmentListAsync()
    {
        try
        {
            return await _service.GetDepartmentListAsync();
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, "DepartmentService.GetDepartmentListAsync encountered an exception.");
            throw;
        }
    }

}
