namespace Ics.OpenApi.Models.Internal.Declare
{
    internal record IcsGetBFSCicRequest
    {
        /// <summary>
        /// 业务流水号
        /// </summary>
        public string BusinessSerial { get; init; }
    }
}
