using CarRental.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Infrastructure.Persistance.Configurations
{
    public class RentalConfiguration : IEntityTypeConfiguration<Rental>
    {
        public void Configure(EntityTypeBuilder<Rental> builder)
        {
            builder.ToTable("Rentals");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.CarId).IsRequired();
            builder.Property(x=>x.UserId).IsRequired();
            builder.Property(x=>x.StartDate).IsRequired();
            builder.Property(x=>x.EndDate).IsRequired();
            builder.Property(x=>x.InsuranceType).IsRequired();
        }
    }
}
