using AcoWeb.API.Entities;

namespace AcoWeb.API.Services;

public interface IEmployeeRepository
{
    public IEnumerable<Employee> GetEmployees(Guid officeId);
    public IEnumerable<Employee> GetEmployees();
}

