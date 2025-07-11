using AutoMapper;
using EAD.Models;
using EAD.ViewModels;

namespace EAD.AutoMapping
{
    public class FtpConfigurationProfile : Profile
    {
        public FtpConfigurationProfile()
        {
            CreateMap<OcrConfigurationViewModel, FtpConfiguration>()
                .ForMember(d => d.Id, o => o.PreCondition(s => s.Id > 0))
                .ForMember(d => d.Directory, o => o.PreCondition(s => s.Directory != null))
                .ForMember(d => d.FileName, o => o.PreCondition(s => s.FileName != null))
                .ForMember(d => d.Host, o => o.PreCondition(s => !string.IsNullOrEmpty(s.Host)))
                .ForMember(d => d.IsSFTP, o => o.PreCondition(s => s.IsSFTP != null))
                .ForMember(d => d.Password, o => o.PreCondition(s => !string.IsNullOrEmpty(s.Password)))
                .ForMember(d => d.Port, o => o.PreCondition(s => s.Port != null && s.Port.Value > 0))
                .ForMember(d => d.Username, o => o.PreCondition(s => !string.IsNullOrEmpty(s.Username)))
                .ForMember(d => d.IsSFTP, o => o.MapFrom(s => s.IsSFTP.Value))
                .ForMember(d => d.Port, o => o.MapFrom(s => s.Port.Value));
        }
    }
}