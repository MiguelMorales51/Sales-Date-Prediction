using backend.Data;
using backend.Models;

namespace backend.Services;

public class CustomerService : ICustomerService
{
    private readonly DatabaseConnection _db;

    public CustomerService(DatabaseConnection db)
    {
        _db = db;
    }

    public async Task<List<SalesDatePredictionDto>> salesDatePredictionAsync()
    {
        string query = @"SELECT c.custid, c.companyname as customerName, 
            max(o.orderdate) as lastOrderDate,
            case when max(o.orderdate) is null then getdate()
            else DATEADD(DAY, avg(day(o.orderdate)), max(o.orderdate)) end as nextPredictedOrder
            FROM Sales.Customers c
            left join Sales.Orders o on c.custid = o.custid
            GROUP BY c.custid, c.companyname
            ORDER BY max(o.orderdate) desc";
        var result = await _db.Select<SalesDatePredictionDto>(query);
        return result;
    }
}
