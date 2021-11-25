namespace Ics.OpenApi.Models.Internal.Declare
{
    /// <summary>
    /// 制单明细
    /// </summary>
    internal record IcsMKDetail
    {
        /// <summary>
        /// 排序
        /// </summary>
        public int SortNo { get; init; }
        /// <summary>
        /// 料号
        /// </summary>
        public string SKU { get; init; }
        /// <summary>
        /// 商品编码
        /// </summary>
        public string HsCode { get; init; }
        /// <summary>
        /// CIQ代码
        /// </summary>
        public string Cciq { get; init; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string CName { get; init; }
        /// <summary>
        /// 英文品名
        /// </summary>
        public string EName { get; init; }
        /// <summary>
        /// 申报要素
        /// </summary>
        public string Description { get; init; }
        /// <summary>
        /// 规格型号
        /// </summary>
        public string Model { get; init; }
        /// <summary>
        /// 成交数量
        /// </summary>
        public decimal? Qty { get; init; }
        /// <summary>
        /// 成交计量单位
        /// </summary>
        public string DeclareUnit { get; init; }
        /// <summary>
        /// 成交计量单位名称
        /// </summary>
        public string DeclareUnitName { get; init; }
        /// <summary>
        /// 法定第一数量
        /// </summary>
        public decimal? LegalQty { get; init; }
        /// <summary>
        /// 法定第一计量单位
        /// </summary>
        public string LegalUnit { get; init; }
        /// <summary>
        /// 法定第一计量单位名称
        /// </summary>
        public string LegalUnitName { get; init; }
        /// <summary>
        /// 第二数量
        /// </summary>
        public decimal? SecondQty { get; init; }
        /// <summary>
        /// 法定第二计量单位
        /// </summary>
        public string SecondUnit { get; init; }
        /// <summary>
        /// 法定第二计量单位名称
        /// </summary>
        public string SecondUnitName { get; init; }
        /// <summary>
        /// 净重(kg)
        /// </summary>
        public decimal? NetWeight { get; init; }
        /// <summary>
        /// 毛重(kg)
        /// </summary>
        public decimal? GrossWeight { get; init; }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal? Price { get; init; }
        /// <summary>
        /// 总价
        /// </summary>
        public decimal? Amount { get; init; }
        /// <summary>
        /// 目的国
        /// </summary>
        public string Country { get; init; }
        /// <summary>
        /// 目的国名称
        /// </summary>
        public string CountryName { get; init; }
        /// <summary>
        /// 原产国
        /// </summary>
        public string FromCountry { get; init; }
        /// <summary>
        /// 原产国名称
        /// </summary>
        public string FromCountryName { get; init; }
        /// <summary>
        /// 原产地区
        /// </summary>
        public string OrginPlace { get; init; }
        /// <summary>
        /// 原产地区名称
        /// </summary>
        public string OrginPlaceName { get; init; }
        /// <summary>
        /// 币制
        /// </summary>
        public string Currency { get; init; }
        /// <summary>
        /// 币制名称
        /// </summary>
        public string CurrencyName { get; init; }
        /// <summary>
        /// 汇率
        /// </summary>
        public decimal? ExchangeRate { get; init; }
        /// <summary>
        /// 境内目的地/货源地
        /// </summary>
        public string TerminiCountry { get; init; }
        /// <summary>
        /// 境内目的地/货源地名称
        /// </summary>
        public string TerminiCountryName { get; init; }
        /// <summary>
        /// 目的地代码/产地代码
        /// </summary>
        public string ChinaRegion { get; init; }
        /// <summary>
        /// 目的地代码/产地名称
        /// </summary>
        public string ChinaRegionName { get; init; }
    }
}
