using backend.Models;

namespace backend.Services;

public interface ICustomerService
{
    Task<List<SalesDatePredictionDto>> salesDatePredictionAsync();
}