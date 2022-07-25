using ORION.Domain.Enums;
using System;

namespace ORION.Domain.Aggregates
{
    public interface IBaseEntity
    {
        DateTime CreateDate { get; set; }
        DateTime? UpdateDate { get; set; }
        DateTime? DeleteDate { get; set; }
        Status Status { get; set; }
    }
}
