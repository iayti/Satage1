﻿namespace Application.Common.Interfaces
{
    using System.Threading;
    using System.Threading.Tasks;
    
    using Microsoft.EntityFrameworkCore;

    using Domain.Entities;

    public interface IApplicationDbContext
    {
        DbSet<City> Cities { get; set; }

        DbSet<VoyagePlan> VoyagePlans { get; set; }

        DbSet<Enrollee> Enrollees { get; set; }

        DbSet<Stop> Stops { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
