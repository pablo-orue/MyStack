using MyStack.Money.Domain;

namespace MyStack.Money.Service
{
    public interface ITradeService
    {
        Task<IEnumerable<Trade>> GetAllAsync();
        Task<Trade?> GetByIdAsync(int id);
        Task<Trade> CreateAsync(Trade trade);
        Task<bool> UpdateAsync(Trade trade);
        Task<bool> DeleteAsync(int id);
    }
}
