using Microsoft.AspNetCore.Mvc;

namespace EmployeeWebApi;

[Route("api/[controller]")]
[ApiController]
public class RoleController: ControllerBase
{
    private readonly IRoleService _service;
    private readonly ILogger<RoleController> _logger;

    public RoleController(ILogger<RoleController> logger, IRoleService service)
    {
        this._service = service;
        _logger = logger;
    }

    [HttpGet("getrolelist")]
    public async Task<List<RoleCompanies>> GetRoleListAsync()
    {
        try
        {
            return await _service.GetRoleListAsync();
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, "RoleService.GetRoleListAsync encountered an exception.");
            throw;
        }
    }
}
