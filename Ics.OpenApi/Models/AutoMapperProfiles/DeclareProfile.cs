using System;
using AutoMapper;
using Ics.OpenApi.Models.Declare;
using Ics.OpenApi.Models.Internal.Declare;

namespace Ics.OpenApi.Models.AutoMapperProfiles
{
    internal class DeclareProfile : Profile
    {
        public DeclareProfile()
        {
            Request2IcsRequest();

            #region 2.1 & 2.2
            Delegate2IcsDelegate();
            IcsDelegate2Delegate();

            Declare2IcsDeclare();
            IcsDeclare2Declare();

            MKDetail2IcsMKDetail();
            IcsMKDetail2MKDetail();

            DDetail2IcsDDetail();
            IcsDDetail2DDetail();
            #endregion

            #region 2.5
            DelegateBox2IcsDelegateBox();
            IcsDelegateBox2DelegateBox();
            #endregion

            #region 2.7
            BFSCic2IcsBFSCic();
            IcsBFSCic2BFSCic();
            #endregion
        }

        TEnum ParseEnum<TEnum>(string input, TEnum defaultValue = default)
            where TEnum : struct
            => Enum.TryParse(input, true, out TEnum output) switch { true => output, _ => defaultValue };

        TEnum ParseEnum<TEnum>(int? input, TEnum defaultValue = default)
            where TEnum : struct
            => !input.HasValue ? defaultValue : ParseEnum<TEnum>(input.ToString(), defaultValue);

        int? Parse(string input, int? defaultValue = default)
            => int.TryParse(input, out var output) switch { true => output, _ => defaultValue };

        decimal? Parse(string input, decimal? defaultValue = default)
            => decimal.TryParse(input, out var output) switch { true => output, _ => defaultValue };

        int? YesNo2Value(YesNo input, int? defaultValue = default)
        {
            if (Enum.IsDefined(typeof(YesNo), input) && input != YesNo.Unknown)
            {
                return (int)input;
            }
            return defaultValue;
        }

        string YesNo2Value(YesNo input, string defaultValue = default)
        {
            var ynv = YesNo2Value(input, (int?)null);
            if (ynv != null)
            {
                return ynv.ToString();
            }
            return defaultValue;
        }

        YesNo Value2YesNo(int? input)
        {
            if (!input.HasValue || !Enum.IsDefined(typeof(YesNo), (YesNo)input.Value))
            {
                return YesNo.Unknown;
            }

            return (YesNo)input.Value;
        }

        YesNo Value2YesNo(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return YesNo.Unknown;
            }
            return Enum.TryParse<YesNo>(input, out var ynv) switch { true => ynv, _ => YesNo.Unknown };
        }

        void Request2IcsRequest()
        {
            CreateMap<GetDelegateRequest, IcsGetDelegateRequest>();
            CreateMap<TransferDelegateRequest, IcsTransferDelegateRequest>();
            CreateMap<TransferStatusRequest, IcsTransferStatusRequest>()
                .ForPath(dm => dm.Status, p => p.MapFrom(s => s.Status == TransferStatus.Unknown ? null : s.Status.ToString("G")));
            CreateMap<GetDelegateBoxRequest, IcsGetDelegateBoxRequest>();
            CreateMap<TransferDelegateBoxRequest, IcsTransferDelegateBoxRequest>();
            CreateMap<GetBFSCicRequest, IcsGetBFSCicRequest>();
            CreateMap<TransferBFSCicRequest, IcsTransferBFSCicRequest>();
        }

        void Delegate2IcsDelegate()
        {
            CreateMap<Declare.Delegate, IcsDelegate>();
        }

        void IcsDelegate2Delegate()
        {
            CreateMap<IcsDelegate, Declare.Delegate>();
        }

        void Declare2IcsDeclare()
        {
            CreateMap<Declare.Declare, IcsDeclare>()
                .ForPath(dm => dm.IeFlag, p => p.MapFrom(s => s.IeFlag.ToString("D")))
                .ForPath(dm => dm.Value1Type, p => p.MapFrom(s => s.Value1Type.ToString("D")))
                .ForPath(dm => dm.Value2Type, p => p.MapFrom(s => s.Value2Type.ToString("D")))
                .ForPath(dm => dm.Value3Type, p => p.MapFrom(s => s.Value3Type.ToString("D")))

                .ForPath(dm => dm.IsRelationConfirm, p => p.MapFrom(s => YesNo2Value(s.IsRelationConfirm, (int?)null)))
                .ForPath(dm => dm.IsPriceConfirm, p => p.MapFrom(s => YesNo2Value(s.IsPriceConfirm, (int?)null)))
                .ForPath(dm => dm.IsPayConfirm, p => p.MapFrom(s => YesNo2Value(s.IsPayConfirm, (int?)null)))

                .ForPath(dm => dm.ForPriceConfirm, p => p.MapFrom(s => YesNo2Value(s.ForPriceConfirm, (string)null)))
                .ForPath(dm => dm.ProPriceConfirm, p => p.MapFrom(s => YesNo2Value(s.ProPriceConfirm, (string)null)))

                .ForPath(dm => dm.IsSelfPayment, p => p.MapFrom(s => s.IsSelfPayment == YesNo.Yes));
        }

        void IcsDeclare2Declare()
        {
            CreateMap<IcsDeclare, Declare.Declare>()
                .ForPath(dm => dm.IeFlag, p => p.MapFrom(s => ParseEnum<IeFlag>(s.IeFlag, IeFlag.Unknown)))
                .ForPath(dm => dm.Value1Type, p => p.MapFrom(s => ParseEnum<ValueNType>(s.Value1Type, ValueNType.Unknown)))
                .ForPath(dm => dm.Value2Type, p => p.MapFrom(s => ParseEnum<ValueNType>(s.Value2Type, ValueNType.Unknown)))
                .ForPath(dm => dm.Value3Type, p => p.MapFrom(s => ParseEnum<ValueNType>(s.Value3Type, ValueNType.Unknown)))

                .ForPath(dm => dm.IsRelationConfirm, p => p.MapFrom(s => Value2YesNo(s.IsRelationConfirm)))
                .ForPath(dm => dm.IsPriceConfirm, p => p.MapFrom(s => Value2YesNo(s.IsPriceConfirm)))
                .ForPath(dm => dm.IsPayConfirm, p => p.MapFrom(s => Value2YesNo(s.IsPayConfirm)))

                .ForPath(dm => dm.ForPriceConfirm, p => p.MapFrom(s => Value2YesNo(s.ForPriceConfirm)))
                .ForPath(dm => dm.ProPriceConfirm, p => p.MapFrom(s => Value2YesNo(s.ProPriceConfirm)))

                .ForPath(dm => dm.IsSelfPayment, p => p.MapFrom(s => s.IsSelfPayment.GetValueOrDefault() ? YesNo.Yes : YesNo.No));
        }

        void MKDetail2IcsMKDetail()
        {
            CreateMap<MKDetail, IcsMKDetail>();
        }

        void IcsMKDetail2MKDetail()
        {
            CreateMap<IcsMKDetail, MKDetail>();
        }

        void DDetail2IcsDDetail()
        {
            CreateMap<DDetail, IcsDDetail>()
                .ForPath(dm => dm.DeclareUnitQty, p => p.MapFrom(s => s.DeclareUnitQty.ToString()))
                .ForPath(dm => dm.LegalQty, p => p.MapFrom(s => s.LegalQty.ToString()))
                .ForPath(dm => dm.SecondQty, p => p.MapFrom(s => s.SecondQty.ToString()))

                .ForPath(dm => dm.LevyType, p => p.MapFrom(s => s.LevyType == LevyType.Unknown ? null : s.LevyType.ToString("D")));
        }

        void IcsDDetail2DDetail()
        {
            CreateMap<IcsDDetail, DDetail>()
                .ForPath(dm => dm.DeclareUnitQty, p => p.MapFrom(s => Parse(s.DeclareUnitQty, null)))
                .ForPath(dm => dm.LegalQty, p => p.MapFrom(s => Parse(s.LegalQty, null)))
                .ForPath(dm => dm.SecondQty, p => p.MapFrom(s => Parse(s.SecondQty, null)))

                .ForPath(dm => dm.LevyType, p => p.MapFrom(s => ParseEnum<LevyType>(s.LevyType, LevyType.Unknown)));
        }

        void DelegateBox2IcsDelegateBox()
        {
            CreateMap<DelegateBox, IcsDelegateBox>()
                .ForPath(dm => dm.BoxWeight, p => p.MapFrom(s => s.BoxWeight.ToString()))
                .ForPath(dm => dm.BoxJoinFlag, p => p.MapFrom(s => s.BoxJoinFlag == BoxJoinFlag.未拼 ? false : true))
                .ForPath(dm => dm.IsKill, p => p.MapFrom(s => s.IsKill == YesNo.Yes))
                .ForPath(dm => dm.IsNucleicAcid, p => p.MapFrom(s => s.IsNucleicAcid == YesNo.Yes));
        }

        void IcsDelegateBox2DelegateBox()
        {
            CreateMap<IcsDelegateBox, DelegateBox>()
                .ForPath(dm => dm.BoxWeight, p => p.MapFrom(s => Parse(s.BoxWeight, null)))
                .ForPath(dm => dm.BoxJoinFlag, p => p.MapFrom(s => s.BoxJoinFlag.GetValueOrDefault() ? BoxJoinFlag.未拼 : BoxJoinFlag.拼箱))
                .ForPath(dm => dm.IsKill, p => p.MapFrom(s => s.IsKill.GetValueOrDefault() ? YesNo.Yes : YesNo.No))
                .ForPath(dm => dm.IsNucleicAcid, p => p.MapFrom(s => s.IsNucleicAcid.GetValueOrDefault() ? YesNo.Yes : YesNo.No));
        }

        void BFSCic2IcsBFSCic()
        {
            CreateMap<BFSCic, IcsBFSCic>();
        }

        void IcsBFSCic2BFSCic()
        {
            CreateMap<IcsBFSCic, BFSCic>();
        }
    }
}
