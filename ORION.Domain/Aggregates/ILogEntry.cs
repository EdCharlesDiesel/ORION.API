using System;
using DDD.DomainLayer;

namespace ORION.Domain.Aggregates
{

    //TODO Look for refactoring
    public interface ILogEntry: IEntity<int>, IBaseEntity
    {
        void FullUpdate(ILogEntry o);

        string FeatureName { get;}
        
        DateTime LogDate { get;}

        string LogType { get;}

        string RequestIpAddress { get;}

        string RequestUrl { get;}

        string ReferrerUrl { get;}

        string UserAgent { get;}

        string Username { get;}

        string Message { get;}        
      
    }
}
