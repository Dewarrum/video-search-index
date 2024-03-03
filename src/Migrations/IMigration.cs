namespace Migrations;

internal interface IMigration
{
    Task Run(CancellationToken cancellationToken = default);
}