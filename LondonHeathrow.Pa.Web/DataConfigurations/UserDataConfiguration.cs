using System;
using LondonHeathrow.Pa.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LondonHeathrow.Pa.Web.DataConfigurations
{
	public class UserDataConfiguration : IEntityTypeConfiguration<UserData>
    {
        public void Configure(EntityTypeBuilder<UserData> builder)
        {

            builder.HasData(
                 new UserData()
                 {
                     Id = Guid.Parse("abce1577-0eb6-4508-8d33-17ebd2b10599"),
                     DisplayName = "Admin",
                     FirstName = "Admin",
                     LastName = "User",
                     CreatedBy = Guid.Parse("abce1577-0eb6-4508-8d33-17ebd2b10599"),
                     CreatedDate = DateTime.UtcNow,
                     ModifiedBy = Guid.Parse("abce1577-0eb6-4508-8d33-17ebd2b10599"),
                     ModifiedDate = DateTime.UtcNow
                 }
             );
        }
    }
}

