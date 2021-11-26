using System.Collections.Generic;

namespace Ics.OpenApi.Models.Internal.Declare
{
    internal record IcsTransferDelegateRequest
    {
        public IcsDeclare Declare { get; init; }
        public List<IcsDDetail> DDetailList { get; init; }
    }
}
