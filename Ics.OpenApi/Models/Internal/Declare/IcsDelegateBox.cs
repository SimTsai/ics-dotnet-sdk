using System;

namespace Ics.OpenApi.Models.Internal.Declare
{
    /// <summary>
    /// 集装箱明细
    /// </summary>
    internal record IcsDelegateBox
    {
        /// <summary>
        /// 集装箱号
        /// </summary>
        public string BoxNo { get; init; }
        /// <summary>
        /// 集装箱规格
        /// </summary>
        public string BoxSpec { get; init; }
        /// <summary>
        /// 自重(KG)
        /// </summary>
        public string BoxWeight { get; init; }
        /// <summary>
        /// 拼箱标识
        /// 1 拼箱 0 未拼
        /// </summary>
        public bool? BoxJoinFlag { get; init; }
        /// <summary>
        /// 商品项号关系
        /// </summary>
        public string GoodsRpGno { get; init; }
        /// <summary>
        /// 箱数量
        /// </summary>
        public int? BoxQuantity { get; init; }
        /// <summary>
        /// 箱型
        /// </summary>
        public string BoxType { get; init; }
        /// <summary>
        /// 箱货重量
        /// </summary>
        public decimal? BoxCargoWeight { get; init; }
        /// <summary>
        /// 要求送达日期
        /// </summary>
        public DateTime? RdDate { get; init; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; init; }
        /// <summary>
        /// 还箱日期
        /// </summary>
        public DateTime? RetunrBoxDate { get; init; }
        /// <summary>
        /// 签收日期
        /// </summary>
        public DateTime? SignDate { get; init; }
        /// <summary>
        /// 签收人
        /// </summary>
        public string SignUser { get; init; }
        /// <summary>
        /// 开始放置日期
        /// </summary>
        public DateTime? BeginPlaceDate { get; init; }
        /// <summary>
        /// 送货地址
        /// </summary>
        public string DeliveryAddr { get; init; }
        /// <summary>
        /// 是否消杀
        /// </summary>
        public bool? IsKill { get; init; }
        /// <summary>
        /// 是否核酸
        /// </summary>
        public bool? IsNucleicAcid { get; init; }
        /// <summary>
        /// 核酸时间
        /// </summary>
        public DateTime? NucleicAcidDate { get; init; }
    }
}
