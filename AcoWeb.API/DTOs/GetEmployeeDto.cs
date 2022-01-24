namespace AcoWeb.API.DTOs;

public class GetEmployeeDto
{  
    public Guid Id { get; set; }
    public string RoleInCompany { get; set; }
    public string FullName { get; set; }
    public DateTimeOffset Hired { get; set; }
}
