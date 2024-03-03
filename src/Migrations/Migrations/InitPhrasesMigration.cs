using Nest;

namespace Migrations.Migrations;

internal sealed class InitPhrasesMigration(IElasticClient client) : IMigration
{
    public async Task Run(CancellationToken cancellationToken = default)
    {
        // ReSharper disable VariableHidesOuterVariable
        await client.Indices.CreateAsync(
            "Videos",
            cid => cid
                .Map<PhraseMigrationDbo>(tmp => tmp
                    .Properties(pd => pd
                        .Keyword(kpd => kpd.Name("id"))
                        .Text(tpd => tpd
                            .Name("text")
                            .Fields(pd => pd
                                .Text(tpd => tpd
                                    .Name("standard")
                                    .Analyzer("standard")
                                )
                                .Text(tpd => tpd
                                    .Name("english")
                                    .Analyzer("english")
                                )
                                .Text(tpd => tpd
                                    .Name("korean")
                                    // TODO: add korean analyzer
                                    .Analyzer("english")
                                )
                            )
                        )
                        .Keyword(kpd => kpd.Name("language"))
                        .Object<PhraseTimingsMigrationDbo>(otd => otd
                            .Properties(pd => pd
                                .Keyword(kpd => kpd.Name("from"))
                                .Keyword(kpd => kpd.Name("to"))
                            )
                            .Enabled(false)
                        )
                    )
                ),
            cancellationToken
        );
    }

    private sealed record PhraseMigrationDbo(
        [property: Keyword(Name = "id")] string Id,
        [property: Text(Name = "text")] string Text,
        [property: Keyword(Name = "language")] Language Language,
        [property: Object(Name = "timings", Enabled = false)]
        PhraseTimingsMigrationDbo Timings
    );

    public sealed record PhraseTimingsMigrationDbo(
        [property: Keyword(Name = "from")] TimeSpan From,
        [property: Keyword(Name = "to")] TimeSpan To
    );
}