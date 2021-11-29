namespace Ics.OpenApi.Models.Internal.Declare
{
    /// <summary>
    /// 获取随附单证 请求
    /// </summary>
    internal record IcsGetBFSCicRequest
    {
        /// <summary>
        /// 业务流水号
        /// </summary>
        public string BusinessSerial { get; init; }
    }
}
