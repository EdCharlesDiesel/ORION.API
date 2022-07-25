
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ORION.DataAccess.Models;

namespace ORION.DataAccess.Interfaces
{
    public interface IOrionDbContext
    {
        DbSet<Person> Persons { get; set; }
        DbSet<PersonBusiness> PersonBusinesss { get; set; }
        DbSet<Relationship> Relationships { get; set; }
        DbSet<Feature> Features { get; set; }
        DbSet<LogEntry> LogEntries { get; set; }
        DbSet<Subscription> Subscriptions { get; set; }
        EntityEntry Entry(object entity);
        int SaveChanges();
    }
}
