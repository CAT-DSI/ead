using AutoMapper;
using EAD.ViewModels;
using System;

namespace EAD.AutoMapping
{
    public class BarcodeFileProfile : Profile
    {
        public BarcodeFileProfile()
        {
            CreateMap<BarcodeFileViewModel, BarcodeFileViewModel>()
                .ForMember(d => d.Barcode, o => o.PreCondition(s => IsValidBarcode(s.Barcode)))
                .ForMember(d => d.Date, o => o.Ignore())
                .ForMember(d => d.Name, o => o.Ignore())
                .ForMember(d => d.OrgUnit, o => o.Ignore())
                .ForMember(d => d.Path, o => o.Ignore())
                .ForMember(d => d.RemotePath, o => o.Ignore());
        }

        private static bool IsValidBarcode(string barcode)
        {
            return !string.IsNullOrEmpty(barcode)
                && !string.Equals(barcode, "No_Barcode", StringComparison.OrdinalIgnoreCase);
        }
    }
}