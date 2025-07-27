

using Microsoft.EntityFrameworkCore;
using MyStack.Infrastructure.EF;

namespace MyStack.KeepAlive.Service
{
    public class KeepAliveService : IKeepAliveService
    {
        private readonly OrueContext _context;

        public KeepAliveService(OrueContext context)
        {
            _context = context;
        }

        public async Task<string?> GetVersionAsync()
        {
            return await _context.Versions
                .Where(v => v.Id == 1)
                .Select(v => v.Value)
                .FirstOrDefaultAsync();
        }
    }
}
