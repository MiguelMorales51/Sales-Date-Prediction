using backend.Models;

namespace backend.Services;

public interface IEmployeeService
{
    Task<List<EmployeesDto>> getEmployees();
}