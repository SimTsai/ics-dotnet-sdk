using System;
using AutoMapper;

namespace Ics.OpenApi.Models.AutoMapperProfiles
{
    internal class DeclareProfile : Profile
    {
        public DeclareProfile()
        {
            Delegate2IcsDelegate(); IcsDelegate2Delegate();
            Declare2IcsDeclare(); IcsDeclare2Declare();
            MKDetail2IcsMKDetail(); IcsMKDetail2MKDetail();
        }

        void Delegate2IcsDelegate()
        {
            CreateMap<Declare.Delegate, Internal.Declare.IcsDelegate>();
        }

        void IcsDelegate2Delegate()
        {
            CreateMap<Internal.Declare.IcsDelegate, Declare.Delegate>();
        }

        void Declare2IcsDeclare()
        {
            CreateMap<Declare.Declare, Internal.Declare.IcsDeclare>()
                .ForPath(dm => dm.IeFlag, p => { p.MapFrom(s => s.IeFlag.ToString("D")); })
                .ForPath(dm => dm.Value1Type, p => { p.MapFrom(s => s.Value1Type.ToString("D")); })
                .ForPath(dm => dm.Value2Type, p => { p.MapFrom(s => s.Value2Type.ToString("D")); })
                .ForPath(dm => dm.Value3Type, p => { p.MapFrom(s => s.Value3Type.ToString("D")); })

                .ForPath(dm => dm.IsRelationConfirm, p => { p.MapFrom(s => s.IsRelationConfirm.ToString("D")); })
                .ForPath(dm => dm.IsPriceConfirm, p => { p.MapFrom(s => s.IsPriceConfirm.ToString("D")); })
                .ForPath(dm => dm.IsPayConfirm, p => { p.MapFrom(s => s.IsPayConfirm.ToString("D")); })
                .ForPath(dm => dm.IsSelfPayment, p => { p.MapFrom(s => s.IsSelfPayment == Declare.YesNo.Yes); });
        }

        TEnum Convert<TEnum>(string input, TEnum defaultValue = default)
            where TEnum : struct
            => Enum.TryParse(input, true, out TEnum output) switch { true => output, _ => defaultValue };

        void IcsDeclare2Declare()
        {
            CreateMap<Internal.Declare.IcsDeclare, Declare.Declare>()
                .ForPath(dm => dm.IeFlag, p => { p.MapFrom(s => Convert<Declare.IeFlag>(s.IeFlag, Declare.IeFlag.Unknown)); })
                .ForPath(dm => dm.Value1Type, p => { p.MapFrom(s => Convert<Declare.ValueNType>(s.Value1Type, Declare.ValueNType.Unknown)); })
                .ForPath(dm => dm.Value2Type, p => { p.MapFrom(s => Convert<Declare.ValueNType>(s.Value2Type, Declare.ValueNType.Unknown)); })
                .ForPath(dm => dm.Value3Type, p => { p.MapFrom(s => Convert<Declare.ValueNType>(s.Value3Type, Declare.ValueNType.Unknown)); })

                .ForPath(dm => dm.IsRelationConfirm, p => { p.MapFrom(s => s.IsRelationConfirm.GetValueOrDefault() == 1 ? Declare.YesNo.Yes : Declare.YesNo.No); })
                .ForPath(dm => dm.IsPriceConfirm, p => { p.MapFrom(s => s.IsPriceConfirm.GetValueOrDefault() == 1 ? Declare.YesNo.Yes : Declare.YesNo.No); })
                .ForPath(dm => dm.IsPayConfirm, p => { p.MapFrom(s => s.IsPayConfirm.GetValueOrDefault() == 1 ? Declare.YesNo.Yes : Declare.YesNo.No); })
                .ForPath(dm => dm.IsSelfPayment, p => { p.MapFrom(s => s.IsSelfPayment.GetValueOrDefault() ? Declare.YesNo.Yes : Declare.YesNo.No); });
        }

        void MKDetail2IcsMKDetail()
        {
            CreateMap<Declare.MKDetail, Internal.Declare.IcsMKDetail>();
        }

        void IcsMKDetail2MKDetail()
        {
            CreateMap<Internal.Declare.IcsMKDetail, Declare.MKDetail>();
        }
    }
}
