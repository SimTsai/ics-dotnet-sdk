namespace Ics.OpenApi.Models.Internal.Declare
{
    /// <summary>
    /// 获取报关单及制单明细 请求
    /// </summary>
    internal record IcsGetDelegateRequest
    {
        /// <summary>
        /// 业务流水号
        /// </summary>
        public string BusinessSerial { get; init; }
    }
}
