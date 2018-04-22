using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProductService.Infrastructure.Services
{
    public interface ICachingProvider
    {
        Task<string> GetStringAsync(string cacheKey);
        Task SetStringAsync(string cacheKey, string cacheValue, TimeSpan absoluteExpirationRelativeToNow);
        bool IsConnect { get; }

        IEnumerable<string> GetKeys();
        Task<bool> DeleteAsync(string cacheKey);
    }
}
