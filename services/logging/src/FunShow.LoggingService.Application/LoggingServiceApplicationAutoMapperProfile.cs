using AutoMapper;
using Volo.Abp.AuditLogging;
using FunShow.LoggingService.Systems.AuditLoggingManagement.Dto;
using AuditLogActionDto = FunShow.LoggingService.Systems.AuditLoggingManagement.Dto.AuditLogActionDto;
using AuditLogDto = FunShow.LoggingService.Systems.AuditLoggingManagement.Dto.AuditLogDto;
using EntityChangeDto = FunShow.LoggingService.Systems.AuditLoggingManagement.Dto.EntityChangeDto;
using EntityPropertyChangeDto = FunShow.LoggingService.Systems.AuditLoggingManagement.Dto.EntityPropertyChangeDto;

namespace FunShow.LoggingService;

public class LoggingServiceApplicationAutoMapperProfile : Profile
{
    public LoggingServiceApplicationAutoMapperProfile()
    {
        
        CreateMap<AuditLog, AuditLogDto>()
            .ForMember(t => t.EntityChanges, option => option.MapFrom(l => l.EntityChanges))
            .ForMember(t => t.Actions, option => option.MapFrom(l => l.Actions));
        CreateMap<EntityChange, EntityChangeDto>()
                .ForMember(t => t.PropertyChanges, option => option.MapFrom(l => l.PropertyChanges));

        CreateMap<AuditLogAction, AuditLogActionDto>();
        CreateMap<EntityPropertyChange, EntityPropertyChangeDto>();

        /* You can configure your AutoMapper mapping configuration here.
        * Alternatively, you can split your mapping configurations
        * into multiple profile classes for a better organization. */
    }
}
