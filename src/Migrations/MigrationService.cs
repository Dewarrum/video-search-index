using Infrastructure.Postgres;
using Infrastructure.Postgres.Migrations;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Migrations;

internal sealed class MigrationService : IMigrationService
{
    private readonly PostgresContext _postgresContext;
    private readonly ILogger _logger;

    public MigrationService(PostgresContext postgresContext, ILogger logger)
    {
        _postgresContext = postgresContext;
        _logger = logger;
    }

    public async Task<IReadOnlyList<MigrationDbo>> GetAll(CancellationToken cancellationToken = default)
    {
        return await _postgresContext.Migrations.ToListAsync(cancellationToken);
    }

    public async Task Insert(string name, CancellationToken cancellationToken = default)
    {
        var migration = new MigrationDbo(name);
        await _postgresContext.Migrations.AddAsync(migration, cancellationToken);
        await _postgresContext.SaveChangesAsync(cancellationToken);
        
        _logger.Information("Migration '{MigrationName}' has been saved", migration.Name);
    }
}