using System;
using LondonHeathrow.Pa.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LondonHeathrow.Pa.Web.DataConfigurations
{
    public class DeviceDataConfiguration : IEntityTypeConfiguration<DeviceData>
    {
        public void Configure(EntityTypeBuilder<DeviceData> builder)
        {
            builder.HasData(
               new DeviceData()
               {
                   Id = "test-device-01",
                   Name = "test device 01",
                   CreatedBy = Guid.Parse("abce1577-0eb6-4508-8d33-17ebd2b10599"),
                   CreatedDate = DateTime.UtcNow,
                   ModifiedBy = Guid.Parse("abce1577-0eb6-4508-8d33-17ebd2b10599"),
                   ModifiedDate = DateTime.UtcNow
               }
           );
        }
    }
}

