using AcoWeb.API.DbContexts;
using AcoWeb.API.Entities;

namespace AcoWeb.API.Services;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly EmployeesContext _context;

    public EmployeeRepository(EmployeesContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public IEnumerable<Employee> GetEmployees(Guid officeId)
    {
        return _context.Employees.Where(e => e.OfficeId == officeId).ToList();
    }

    public IEnumerable<Employee> GetEmployees()
    {
        return _context.Employees.ToList();
    }
}

