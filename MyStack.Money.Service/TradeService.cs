using Microsoft.EntityFrameworkCore;
using MyStack.Infrastructure.EF;
using MyStack.Money.Domain;

namespace MyStack.Money.Service
{
    internal class TradeService : ITradeService
    {
        private readonly OrueContext _context;

        public TradeService(OrueContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Trade>> GetAllAsync()
        {
            return await _context.Trades.ToListAsync();
        }

        public async Task<Trade?> GetByIdAsync(int id)
        {
            return await _context.Trades.FindAsync(id);
        }

        public async Task<Trade> CreateAsync(Trade trade)
        {
            _context.Trades.Add(trade);
            await _context.SaveChangesAsync();
            return trade;
        }

        public async Task<bool> UpdateAsync(Trade trade)
        {
            var existing = await _context.Trades.FindAsync(trade.Id);
            if (existing is null)
            {
                return false;
            }
            _context.Entry(existing).CurrentValues.SetValues(trade);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var trade = await _context.Trades.FindAsync(id);
            if (trade is null)
            {
                return false;
            }
            _context.Trades.Remove(trade);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
