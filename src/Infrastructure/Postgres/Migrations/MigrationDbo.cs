namespace Infrastructure.Postgres.Migrations;

public sealed class MigrationDbo
{
    public MigrationDbo(string name)
    {
        Name = name;
        AppliedAt = DateTime.UtcNow;
    }

    public string Name { get; private set; }
    public DateTime AppliedAt { get; private set; }
}