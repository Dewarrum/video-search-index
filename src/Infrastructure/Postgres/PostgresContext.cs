using Infrastructure.Postgres.Migrations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Postgres;

public sealed class PostgresContext : DbContext
{
    public PostgresContext()
    {
        Migrations = Set<MigrationDbo>();
    }

    public DbSet<MigrationDbo> Migrations { get; }
}