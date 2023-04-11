using AircraftSpotter.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftSpotter.Infrastructure.Configurations
{
    public class AircraftSightingConfiguration : IEntityTypeConfiguration<AircraftSighting>
    {
        public void Configure(EntityTypeBuilder<AircraftSighting> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Make)
                .IsRequired();

            builder.Property(x => x.Model)
                .IsRequired();

            builder.Property(x => x.Registration)
                .IsRequired();

            builder.Property(x => x.Location)
                .IsRequired();
        }
    }

}
