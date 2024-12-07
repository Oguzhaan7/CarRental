using CarRental.Domain.Entities;
using CarRental.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Infrastructure.Persistance.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("Cars");
            builder.HasKey(x=>x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x=>x.Brand).HasMaxLength(50).IsRequired();
            builder.Property(x=>x.Model).HasMaxLength(50).IsRequired();
            builder.Property(x=>x.Plate).HasMaxLength(8).IsRequired();
            builder.Property(x=>x.IsAvailable).IsRequired();
            builder.Property(x=>x.Year).IsRequired();
            builder.Property(x => x.FuelType).IsRequired();
            builder.Property(x => x.DailyPrice).IsRequired();
            builder.Property(x => x.TransmissionType).IsRequired();
        }
    }
}
