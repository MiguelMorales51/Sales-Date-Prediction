namespace backend.Models;

public class SalesDatePredictionDto
{
    public int? custid { get; set; }
    public string? customerName { get; set; }
    public DateTime? lastOrderDate { get; set; }
    public DateTime? nextPredictedOrder { get; set; }
}