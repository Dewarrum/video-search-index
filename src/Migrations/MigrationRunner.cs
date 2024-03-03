using Serilog;
using Serilog.Context;

namespace Migrations;

internal sealed class MigrationRunner(
    IMigrationService migrationService,
    IEnumerable<IMigration> migrations,
    ILogger logger)
{
    public async Task Run(CancellationToken cancellationToken = default)
    {
        var appliedMigrations = await migrationService.GetAll(cancellationToken);
        var appliedMigrationNames = appliedMigrations.Select(m => m.Name).ToHashSet();

        foreach (var migration in migrations)
        {
            var migrationName = migration.GetType().Name;
            using var _ = LogContext.PushProperty("migrationName", migrationName);

            if (!appliedMigrationNames.Contains(migrationName))
            {
                await ApplyMigration(migration, migrationName, cancellationToken);
                continue;
            }

            logger.Information("Migration has been already applied, skipping");
        }
    }

    private async Task ApplyMigration(
        IMigration migration,
        string migrationName,
        CancellationToken cancellationToken = default)
    {
        logger.Information("Running migration");

        try
        {
            await migration.Run(cancellationToken);
        }
        catch (Exception e)
        {
            logger.Error(e, "Failed to apply migration");
            throw;
        }

        try
        {
            await migrationService.Insert(migrationName, cancellationToken);
        }
        catch (Exception e)
        {
            logger.Error(e, "Failed to save migration in database");
            throw;
        }

        logger.Information("Migration has been successfully applied");
    }
}