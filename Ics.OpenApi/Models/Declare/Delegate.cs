﻿using System.Collections.Generic;

namespace Ics.OpenApi.Models.Declare
{
    /// <summary>
    /// 委托单
    /// </summary>
    public record Delegate
    {
        /// <summary>
        /// 报关单 表头
        /// </summary>
        public Declare Declare { get; init; }
        /// <summary>
        /// 报关单 商品明细
        /// </summary>
        public List<MKDetail> MKDetailList { get; init; }
    }
}
