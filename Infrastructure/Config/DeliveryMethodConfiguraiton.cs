using System;
using System.Security.Cryptography.X509Certificates;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config;

public class DeliveryMethodConfiguraiton : IEntityTypeConfiguration<DeliveryMethod>
{
    public void Configure(EntityTypeBuilder<DeliveryMethod> builder)
    {
        builder.Property(x=> x.Price).HasColumnType("decimal(18,2)");
    }
}
