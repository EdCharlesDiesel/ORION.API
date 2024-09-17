
using System;
using DDD.DomainLayer;
using ORION.Domain.Aggregates;
using ORION.Domain.Enums;
using ORION.Domain.Tools;

namespace ORION.DataAccess.Models
{
    public class LogEntry : Entity<int>, ILogEntry
    {        
        public void FullUpdate(ILogEntry o)
        {
            if (IsTransient())
            {
                Id = o.Id;
            }

            FeatureName = o.FeatureName;
            LogDate = o.LogDate;
            LogType = o.LogType;
            RequestIpAddress = o.RequestIpAddress;
            RequestUrl = o.RequestUrl;
            ReferrerUrl = o.ReferrerUrl;
            UserAgent = o.UserAgent;
            Username = o.Username;
            Message = o.Message;
        } 
    
        public string FeatureName { get; set; }

        public DateTime LogDate { get; set; }

        public string LogType { get; set; }

        public string RequestIpAddress { get; set; }

        public string RequestUrl { get; set; }

        public string ReferrerUrl { get; set; }

        public string UserAgent { get; set; }

        public string Username { get; set; }

        public string Message { get; set; }

        private DateTime _createDate = DateTime.Now;

        public DateTime CreateDate { get => _createDate; set => _createDate = value; }

        public DateTime? UpdateDate { get; set; }

        public DateTime? DeleteDate { get; set; }

        private Status _status = Status.Active;

        public Status Status { get => _status; set => _status = value; }

    }
}
