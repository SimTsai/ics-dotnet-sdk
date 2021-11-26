namespace Ics.OpenApi.Models.Internal.Declare
{
    /// <summary>
    /// 随附单证
    /// </summary>
    internal record IcsBFSCic
    {
        /// <summary>
        /// 单证代码
        /// </summary>
        public string CicCode { get; init; }
        /// <summary>
        /// 随附单证编号
        /// </summary>
        public string CicNo { get; init; }
    }
}
