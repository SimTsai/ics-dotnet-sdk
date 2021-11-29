namespace Ics.OpenApi.Models.Internal.Declare
{
    /// <summary>
    /// 获取报关单集装箱明细 请求
    /// </summary>
    internal record IcsGetDelegateBoxRequest
    {
        /// <summary>
        /// 业务流水号
        /// </summary>
        public string BusinessSerial { get; init; }
    }
}
