using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeWebApi;

public class Employees
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int EmployeeId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int RoleCompany { get; set; }
    public int DepartmentId { get; set; }
    public int AgeDate { get; set; }
    public int CarOwner { get; set; }
    public string UserName { get; set; } = string.Empty;
    //[NotMapped]
    //public string DepartmentName { get; set; } = string.Empty;
    //[NotMapped]
    //public string RoleName { get; set; } = string.Empty;
}
