using System;

namespace Ics.OpenApi.Models.Declare
{
    /// <summary>
    /// 报关单
    /// </summary>
    public record Declare
    {
        /// <summary>
        /// 业务流水号
        /// </summary>
        public string BusinessSerial { get; init; }
        /// <summary>
        /// 进出口标志
        /// </summary>
        public IeFlag IeFlag { get; init; }
        /// <summary>
        /// 业务范围
        /// </summary>
        public string BusinessArea { get; init; }
        /// <summary>
        /// 业务范围名称
        /// </summary>
        public string BusinessAreaName { get; init; }
        /// <summary>
        /// 业务类型
        /// </summary>
        public string BusinessType { get; init; }
        /// <summary>
        /// 业务类型名称
        /// </summary>
        public string BusinessTypeName { get; init; }
        /// <summary>
        /// 业务类型名称
        /// </summary>
        public string DeliveryNum { get; init; }
        /// <summary>
        /// 货代社会信用号
        /// </summary>
        public string ForWarderCreditNo { get; init; }
        /// <summary>
        /// 货代名称
        /// </summary>
        public string ForWarderName { get; init; }
        /// <summary>
        /// 报关行社会信用号
        /// </summary>
        public string CustomsBrokerCreditNo { get; init; }
        /// <summary>
        /// 报关行名称
        /// </summary>
        public string CustomsBrokerName { get; init; }
        /// <summary>
        /// 发票号
        /// </summary>
        public string InvoiveNo { get; init; }
        /// <summary>
        /// 总金额
        /// </summary>
        public decimal? TotalAmount { get; init; }
        /// <summary>
        /// 预录入编号
        /// </summary>
        public string PreUniformNo { get; init; }
        /// <summary>
        /// 海关编号
        /// </summary>
        public string CustomsNo { get; init; }
        /// <summary>
        /// 申报地海关编号
        /// </summary>
        public string DeclareCustoms { get; init; }
        /// <summary>
        /// 申报地海关名称
        /// </summary>
        public string DeclareCustomsName { get; init; }
        /// <summary>
        /// 境内收发货人社会信用号
        /// </summary>
        public string ReceiverCreditNo { get; init; }
        /// <summary>
        /// 境内收发货人
        /// </summary>
        public string ReceiverName { get; init; }
        /// <summary>
        /// 进境关别/出境关别
        /// </summary>
        public string IEImport { get; init; }
        /// <summary>
        /// 进境关别/出境关别 名称
        /// </summary>
        public string IEImportName { get; init; }
        /// <summary>
        /// 进口日期/出境日期
        /// </summary>
        public DateTime? IEDate { get; init; }
        /// <summary>
        /// 申报日期
        /// </summary>
        public DateTime? DeclareDate { get; init; }
        /// <summary>
        /// 备案号
        /// </summary>
        public string RecordNo { get; init; }
        /// <summary>
        /// 境外收发货人社会信用代码
        /// </summary>
        public string ConsignorCreditNo { get; init; }
        /// <summary>
        /// 境外收发货人
        /// </summary>
        public string ConsignorName { get; init; }
        /// <summary>
        /// 运输方式
        /// </summary>
        public string TrafficType { get; init; }
        /// <summary>
        /// 运输方式名称
        /// </summary>
        public string TrafficTypeName { get; init; }
        /// <summary>
        /// 运输工具
        /// </summary>
        public string TrafficTools { get; init; }
        /// <summary>
        /// 航次号
        /// </summary>
        public string VoyageNo { get; init; }
        /// <summary>
        /// 获取存放地点
        /// </summary>
        public string GoodsLocation { get; init; }
        /// <summary>
        /// 生产销售单位/消费使用单位社会信用代码
        /// </summary>
        public string ConsigneeCreditNo { get; init; }
        /// <summary>
        /// 生产销售单位/消费使用单位
        /// </summary>
        public string ConsigneeName { get; init; }
        /// <summary>
        /// 监管方式
        /// </summary>
        public string RegulatoryType { get; init; }
        /// <summary>
        /// 监管方式名称
        /// </summary>
        public string RegulatoryTypeName { get; init; }
        /// <summary>
        /// 征免性质
        /// </summary>
        public string LevyType { get; init; }
        /// <summary>
        /// 征免性质名称
        /// </summary>
        public string LevyTypeName { get; init; }
        /// <summary>
        /// 许可证号
        /// </summary>
        public string LicenceNo { get; init; }
        /// <summary>
        /// 启运港
        /// </summary>
        public string ShipmentPort { get; init; }
        /// <summary>
        /// 启运港名称
        /// </summary>
        public string ShipmentPortName { get; init; }
        /// <summary>
        /// 合同协议号
        /// </summary>
        public string ContractAgt { get; init; }
        /// <summary>
        /// 贸易国别(地区)
        /// </summary>
        public string TradeCountry { get; init; }
        /// <summary>
        /// 贸易国别(地区)名称
        /// </summary>
        public string TradeCountryName { get; init; }
        /// <summary>
        /// 启运国/运抵国
        /// </summary>
        public string FromCountry { get; init; }
        /// <summary>
        /// 启运国/运抵国名称
        /// </summary>
        public string FromCountryName { get; init; }
        /// <summary>
        /// 经停港/指运港
        /// </summary>
        public string FromPort { get; init; }
        /// <summary>
        /// 经停港/指运港名称
        /// </summary>
        public string FromPortName { get; init; }
        /// <summary>
        /// 入境口岸/离境口岸
        /// </summary>
        public string DomesticPort { get; init; }
        /// <summary>
        /// 入境口岸/离境口岸名称
        /// </summary>
        public string DomesticPortName { get; init; }
        /// <summary>
        /// 包装种类
        /// </summary>
        public string PackType { get; init; }
        /// <summary>
        /// 包装种类名称
        /// </summary>
        public string PackTypeName { get; init; }
        /// <summary>
        /// 件数
        /// </summary>
        public int? CaseCount { get; init; }
        /// <summary>
        /// 毛重(kg)
        /// </summary>
        public decimal? GrossWeight { get; init; }
        /// <summary>
        /// 净重(kg)
        /// </summary>
        public decimal? NetWeight { get; init; }
        /// <summary>
        /// 成交方式
        /// </summary>
        public string ShipTerrmType { get; init; }
        /// <summary>
        /// 成交方式名称
        /// </summary>
        public string ShipTerrmTypeName { get; init; }
        /// <summary>
        /// 运费
        /// </summary>
        public decimal? CarriageFee { get; init; }
        /// <summary>
        /// 运费币制
        /// </summary>
        public string CarriageFeeCurrency { get; init; }
        /// <summary>
        /// 值类型1
        /// 1:费率 2:单价 3:总价
        /// </summary>
        public ValueNType Value1Type { get; init; }
        /// <summary>
        /// 保费
        /// </summary>
        public decimal? InsuranceFee { get; init; }
        /// <summary>
        /// 保费币制
        /// </summary>
        public string InsuranceFeeCurrency { get; init; }
        /// <summary>
        /// 值类型2
        /// 1:费率 2:单价 3:总价
        /// </summary>
        public ValueNType Value2Type { get; init; }
        /// <summary>
        /// 杂费
        /// </summary>
        public decimal? OtherFee { get; init; }
        /// <summary>
        /// 杂费币制
        /// </summary>
        public string OtherFeeCurrency { get; init; }
        /// <summary>
        /// 值类型3
        /// 1:费率 2:单价 3:总价
        /// </summary>
        public ValueNType Value3Type { get; init; }
        /// <summary>
        /// 随附单证
        /// </summary>
        public string Atrachment { get; init; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; init; }
        /// <summary>
        /// 标记唛码及备注
        /// </summary>
        public string Remark2 { get; init; }
        /// <summary>
        /// 特殊关系确认
        /// </summary>
        public YesNo IsRelationConfirm { get; init; }
        /// <summary>
        /// 价格影响确认
        /// </summary>
        public YesNo IsPriceConfirm { get; init; }
        /// <summary>
        /// 支付特许权使用费确认
        /// </summary>
        public YesNo IsPayConfirm { get; init; }
        /// <summary>
        /// 自报自缴
        /// </summary>
        public YesNo IsSelfPayment { get; init; }
        /// <summary>
        /// 公式定价确认
        /// </summary>
        public string ForPriceConfirm { get; init; }
        /// <summary>
        /// 暂定价格确认
        /// </summary>
        public string ProPriceConfirm { get; init; }
        /// <summary>
        /// 检验检疫编号
        /// </summary>
        public string InspectionNo { get; init; }
        /// <summary>
        /// 检验检疫时间
        /// </summary>
        public DateTime? InspectionDate { get; init; }
    }
}
