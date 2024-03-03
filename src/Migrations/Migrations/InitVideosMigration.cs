using Nest;

namespace Migrations.Migrations;

public sealed class InitVideosMigration(IElasticClient client) : IMigration
{
    public async Task Run(CancellationToken cancellationToken = default)
    {
        // ReSharper disable VariableHidesOuterVariable
        await client.Indices.CreateAsync(
            "Videos",
            cid => cid
                .Map<VideoMigrationDbo>(tmp => tmp
                    .Properties(pd => pd
                        .Keyword(kpd => kpd.Name("id"))
                        .Text(tpd => tpd.Name("title"))
                        .Keyword(kpd => kpd.Name("uri"))
                        .Number(npd => npd.Name("seriesNumber"))
                    )
                ),
            cancellationToken
        );
    }

    private sealed record VideoMigrationDbo(
        [property: Keyword(Name = "id")] string Id,
        [property: Text(Name = "title")] string Title,
        [property: Keyword(Name = "uri")] string Uri,
        [property: Number(Name = "seriesNumber")]
        int? SeriesNumber
    );
}