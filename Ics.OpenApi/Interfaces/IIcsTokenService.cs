using System.Threading.Tasks;

namespace Ics.OpenApi.Interfaces
{
    /// <summary>
    /// 跨境无忧ICS Token服务
    /// </summary>
    public interface IIcsTokenService
    {
        /// <summary>
        /// 获取Token
        /// </summary>
        /// <returns></returns>
        Task<string> GetTokenAsync();
    }
}
