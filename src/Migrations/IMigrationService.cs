using Infrastructure.Postgres.Migrations;

namespace Migrations;

internal interface IMigrationService
{
    Task<IReadOnlyList<MigrationDbo>> GetAll(CancellationToken cancellationToken = default);
    Task Insert(string name, CancellationToken cancellationToken = default);
}