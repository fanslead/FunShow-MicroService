﻿using FunShow.LoggingService.Systems.AuditLoggingManagement.Dto;
using FunShow.LoggingService.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.AuditLogging;
using AuditLogDto = FunShow.LoggingService.Systems.AuditLoggingManagement.Dto.AuditLogDto;
using GetAverageExecutionDurationPerDayOutput = FunShow.LoggingService.Systems.AuditLoggingManagement.Dto.GetAverageExecutionDurationPerDayOutput;
using GetAverageExecutionDurationPerDayInput = FunShow.LoggingService.Systems.AuditLoggingManagement.Dto.GetAverageExecutionDurationPerDayInput;

namespace FunShow.LoggingService.Systems.AuditLoggingManagement
{
    [Authorize(LoggingServicePermissions.AuditLogging.Default)]
    public class AuditLoggingAppService : ApplicationService, IAuditLoggingAppService
    {
        private readonly IAuditLogRepository _auditLogRepository;
        public AuditLoggingAppService(
            IAuditLogRepository auditLogRepository)
        {
            _auditLogRepository = auditLogRepository;
        }

        public async Task<AuditLogDto> Get(Guid id)
        {
            var auditLog = await _auditLogRepository.GetAsync(id);

            return ObjectMapper.Map<AuditLog, AuditLogDto>(auditLog);
        }

        public async Task<PagedResultDto<AuditLogDto>> GetAll(GetAuditLogsInput input)
        {
            var count = await _auditLogRepository.GetCountAsync(httpMethod: input.HttpMethod, url: input.Url,
                userName: input.UserName, applicationName: input.ApplicationName, correlationId: input.CorrelationId, maxExecutionDuration: input.MaxExecutionDuration,
                minExecutionDuration: input.MinExecutionDuration, hasException: input.HasException, httpStatusCode: input.HttpStatusCode);
            var list = await _auditLogRepository.GetListAsync(sorting: input.Sorting,maxResultCount: input.MaxResultCount, skipCount: input.SkipCount, httpMethod: input.HttpMethod, url: input.Url,
                userName: input.UserName, applicationName: input.ApplicationName, correlationId: input.CorrelationId, maxExecutionDuration: input.MaxExecutionDuration,
                minExecutionDuration: input.MinExecutionDuration, hasException: input.HasException, httpStatusCode: input.HttpStatusCode);

            return new PagedResultDto<AuditLogDto>(
                count,
                ObjectMapper.Map<List<AuditLog>, List<AuditLogDto>>(list)
            );
        }

        public async Task<GetAverageExecutionDurationPerDayOutput> GetAverageExecutionDurationPerDay(GetAverageExecutionDurationPerDayInput input)
        {
            var data = await _auditLogRepository.GetAverageExecutionDurationPerDayAsync(input.StartDate, input.EndDate);
            return new GetAverageExecutionDurationPerDayOutput()
            {

                Data = data
            };
        }
    }
}
