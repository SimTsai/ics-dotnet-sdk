using System;
using System.Threading.Tasks;

namespace Ics.OpenApi.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITokenStorageService : IDisposable
    {
        /// <summary>
        /// 存储Token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task SaveTokenAsync(string token);
        /// <summary>
        /// 读取Token
        /// </summary>
        /// <returns></returns>
        Task<string> LoadTokenAsync();
    }
}
