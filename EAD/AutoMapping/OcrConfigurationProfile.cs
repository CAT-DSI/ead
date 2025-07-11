using AutoMapper;
using EAD.Models;
using EAD.ViewModels;

namespace EAD.AutoMapping
{
    public class OcrConfigurationProfile : Profile
    {
        public OcrConfigurationProfile()
        {
            CreateMap<OcrConfigurationViewModel, OcrConfiguration>()
                .ForMember(d => d.Id, o => o.PreCondition(s => s.Id > 0))
                .ForMember(d => d.FtpConfigurationId, o => o.PreCondition(s => s.FtpConfigurationId > 0))
                .ForMember(d => d.CreatedById, o => o.Ignore())
                .ForMember(d => d.CreatedDate, o => o.Ignore())
                .ForMember(d => d.BarcodeLength, o => o.PreCondition(s => s.BarcodeLength > 0))
                .ForMember(d => d.BarcodeSuffix, o => o.PreCondition(s => s.BarcodeSuffix != null))
                .ForMember(d => d.BarcodePrefix, o => o.PreCondition(s => s.BarcodePrefix != null))
                .ForMember(d => d.DirectoryPath, o => o.PreCondition(s => !string.IsNullOrEmpty(s.DirectoryPath)))
                .ForMember(d => d.Name, o => o.PreCondition(s => !string.IsNullOrEmpty(s.Name)))
                .ForMember(d => d.UpdatedById, o => o.Ignore())
                .ForMember(d => d.UpdatedDate, o => o.Ignore());
        }
    }
}