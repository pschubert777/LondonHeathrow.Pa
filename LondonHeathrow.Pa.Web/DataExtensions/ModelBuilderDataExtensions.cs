using Microsoft.EntityFrameworkCore;

namespace LondonHeathrow.Pa.Web.DataExtensions;

public static class ModelBuilderDataExtensions
{
    public static void SetForeignKeyConstraints(this ModelBuilder modelBuilder)
    {
        foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
        }

    }
}