namespace Ics.OpenApi.Models.Internal.Declare
{
    internal record IcsGetDelegateRequest
    {
        /// <summary>
        /// 业务流水号
        /// </summary>
        public string BusinessSerial { get; init; }
    }
}
