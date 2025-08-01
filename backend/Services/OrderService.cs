using System.Transactions;
using backend.Data;
using backend.Models;

namespace backend.Services;

public class OrderService : IOrderService
{
    private readonly DatabaseConnection _db;

    public OrderService(DatabaseConnection db)
    {
        _db = db;
    }

    public async Task<List<OrderCustomerDto>> getClientOrders(int custid)
    {
        Dictionary<string, dynamic> dic = new Dictionary<string, dynamic>();
        string query = @"SELECT orderid, requireddate, shippeddate, shipname, shipaddress, shipcity
            FROM Sales.Orders
            WHERE custid = @custid";
        dic.Add("@custid", custid);
        var result = await _db.Select<OrderCustomerDto>(query, dic);
        return result;
    }

    public async Task<object> addNewOrder(SaveOrderDto order)
    {
        Dictionary<string, dynamic?> dic = new Dictionary<string, dynamic?>();
        string query = "";
        /*Guardar Orden y detalle*/
        using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(0, 20, 0)))
        {
            query = @"INSERT INTO Sales.Orders(custid,empid,orderdate,requireddate,shippeddate,shipperid,freight,shipname,shipaddress,shipcity,shipcountry)
                VALUES(@custid,@empid,@orderdate,@requireddate,@shippeddate,@shipperid,@freight,@shipname,@shipaddress,@shipcity,@shipcountry)";
            dic.Add("@custid", order.custid);
            dic.Add("@empid", order.empid);
            dic.Add("@orderdate", order.orderdate);
            dic.Add("@requireddate", order.requireddate);
            dic.Add("@shippeddate", order.shippeddate);
            dic.Add("@shipperid", order.shipperid);
            dic.Add("@freight", order.freight);
            dic.Add("@shipname", order.shipname);
            dic.Add("@shipaddress", order.shipaddress);
            dic.Add("@shipcity", order.shipcity);
            dic.Add("@shipcountry", order.shipcountry);

            bool save = await _db.Insert(query, dic);
            if (!save)
            {
                return new
                {
                    Complete = false,
                    Error = "Error saving the order"
                };
            }

            //Obtener id
            dic.Clear();
            query = @"SELECT MAX(orderid) as orderid 
                FROM Sales.Orders";
            List<SaveOrderDto> lst = await _db.Select<SaveOrderDto>(query);
            int? orderid = lst[0].orderid;

            //guardar detalle
            query = @"INSERT INTO Sales.OrderDetails(orderid,productid,unitprice,qty,discount)
                VALUES(@orderid,@productid,@unitprice,@qty,@discount)";
            dic.Add("@orderid", orderid);
            dic.Add("@productid", order.details?.productid);
            dic.Add("@unitprice", order.details?.unitprice);
            dic.Add("@qty", order.details?.qty);
            dic.Add("@discount", order.details?.discount);

            save = await _db.Insert(query, dic);
            if (!save)
            {
                return new
                {
                    Complete = false,
                    Error = "Error saving details of the order"
                };
            }

            scope.Complete();
        }

        return new
        {
            Complete = true,
            Error = "Order saved successfully."
        };
    }
}