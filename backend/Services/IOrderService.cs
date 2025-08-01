using backend.Models;

namespace backend.Services;

public interface IOrderService
{
    Task<List<OrderCustomerDto>> getClientOrders(int custid);

    Task<object> addNewOrder(SaveOrderDto order);
}