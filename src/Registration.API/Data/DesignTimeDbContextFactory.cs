
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Npgsql;

namespace Registration.API.Data;

public class DesignTimeDbContextFactory
    : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var connectionString =
            Environment.GetEnvironmentVariable(
                "ConnectionStrings__DefaultConnection");

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            var password =
                Environment.GetEnvironmentVariable("POSTGRES_PASSWORD")
                ?? "design-time-only";

            var builder = new NpgsqlConnectionStringBuilder
            {
                Host = "course-registration-db",
                Port = 5432,
                Database = "RegistrationDb",
                Username = "courseuser",
                Password = password
            };

            connectionString = builder.ConnectionString;
        }

        var optionsBuilder =
            new DbContextOptionsBuilder<ApplicationDbContext>();

        optionsBuilder.UseNpgsql(connectionString);

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}
