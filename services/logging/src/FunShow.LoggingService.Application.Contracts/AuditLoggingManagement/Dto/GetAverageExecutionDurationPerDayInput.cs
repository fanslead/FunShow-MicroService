using System;

namespace FunShow.LoggingService.Systems.AuditLoggingManagement.Dto
{
    public class GetAverageExecutionDurationPerDayInput
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
