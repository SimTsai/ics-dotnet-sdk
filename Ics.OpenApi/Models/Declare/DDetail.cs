namespace Ics.OpenApi.Models.Declare
{
    /// <summary>
    /// 申报明细
    /// </summary>
    public record DDetail
    {
        /// <summary>
        /// 排序
        /// </summary>
        public int SortNo { get; init; }
        /// <summary>
        /// CIQ代码
        /// </summary>
        public string Cciq { get; init; }
        /// <summary>
        /// 商品编码
        /// </summary>
        public string HsCode { get; init; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string CName { get; init; }
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
        public decimal? DeclareUnitQty { get; init; }
        /// <summary>
        /// 成交计量单位
        /// </summary>
        public string DeclareUnit { get; init; }
        /// <summary>
        /// 成交单位代码
        /// </summary>
        public string DeclareUnitCode { get; init; }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal? Price { get; init; }
        /// <summary>
        /// 总价
        /// </summary>
        public decimal? Amount { get; init; }
        /// <summary>
        /// 币制
        /// </summary>
        public string Currency { get; init; }
        /// <summary>
        /// 币制代码
        /// </summary>
        public string CurrencyCode { get; init; }
        /// <summary>
        /// 产地国/目的国
        /// </summary>
        public string Country { get; init; }
        /// <summary>
        /// 产地国/目的国代码
        /// </summary>
        public string CountryCode { get; init; }
        /// <summary>
        /// 原产国
        /// </summary>
        public string FromCountry { get; init; }
        /// <summary>
        /// 原产国代码
        /// </summary>
        public string FromCountryCode { get; init; }
        /// <summary>
        /// 征免性质
        /// </summary>
        public LevyType LevyType { get; init; }
        /// <summary>
        /// 征免性质名称
        /// </summary>
        public string LevyTypeName { get; init; }
        /// <summary>
        /// 境内目的地/货源地
        /// </summary>
        public string TerminiCountry { get; init; }
        /// <summary>
        /// 境内目的地/货源地名称
        /// </summary>
        public string TerminiCountryName { get; init; }
        /// <summary>
        /// 目的地代码
        /// </summary>
        public string DestinationCode { get; init; }
        /// <summary>
        /// 目的地名称
        /// </summary>
        public string DestinationName { get; init; }
        /// <summary>
        /// 法定第一数量
        /// </summary>
        public decimal? LegalQty { get; init; }
        /// <summary>
        /// 法定第一计量单位
        /// </summary>
        public string LegalUnit { get; init; }
        /// <summary>
        /// 法定单位代码
        /// </summary>
        public string LegalUnitCode { get; init; }
        /// <summary>
        /// 第二数量
        /// </summary>
        public decimal? SecondQty { get; init; }
        /// <summary>
        /// 法定第二计量单位
        /// </summary>
        public string SecondUnit { get; init; }
        /// <summary>
        /// 第二单位代码
        /// </summary>
        public string SecondUnitCode { get; init; }
        /// <summary>
        /// 原产地区代码
        /// </summary>
        public string OrginPlace { get; init; }
        /// <summary>
        /// 原产地区名称
        /// </summary>
        public string OrginPlaceName { get; init; }
    }
}
