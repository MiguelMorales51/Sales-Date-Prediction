namespace backend.Models;

public class OrderCustomerDto
{
    public int? orderid { get; set; }
    public DateTime? requireddate { get; set; }
    public DateTime? shippeddate { get; set; }
    public string? shipname { get; set; }
    public string? shipaddress { get; set; }
    public string? shipcity { get; set; }
}

public class SaveOrderDto
{
    public int? orderid { get; set; }
    public int? custid { get; set; }
    public int? empid { get; set; }
    public DateTime? orderdate { get; set; }
    public DateTime? requireddate { get; set; }
    public DateTime? shippeddate { get; set; }
    public int? shipperid { get; set; }
    public decimal? freight { get; set; }
    public string? shipname { get; set; }
    public string? shipaddress { get; set; }
    public string? shipcity { get; set; }
    public string? shipcountry { get; set; }
    public SaveOrderDetailsDto? details { get; set; }
}

public class SaveOrderDetailsDto
{
    public int? orderid{ get; set; }
    public int? unitprice { get; set; }
    public decimal? productid { get; set; }
    public int? qty { get; set; }
    public decimal? discount { get; set; }
}