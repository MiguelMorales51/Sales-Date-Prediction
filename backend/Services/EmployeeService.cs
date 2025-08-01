using backend.Data;
using backend.Models;

namespace backend.Services;

public class EmployeeService : IEmployeeService
{
    private readonly DatabaseConnection _db;

    public EmployeeService(DatabaseConnection db)
    {
        _db = db;
    }

    public async Task<List<EmployeesDto>> getEmployees()
    {
        string query = @"SELECT empid, firstname + ' ' + lastname as EmpName
            FROM HR.Employees";
        var result = await _db.Select<EmployeesDto>(query);
        return result;
    }
}
