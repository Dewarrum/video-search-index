using Nest;

namespace Infrastructure.Elasticsearch.Phrases;

public sealed record PhraseTimingsDbo(
    [property: Keyword(Name = "from")] TimeSpan From,
    [property: Keyword(Name = "to")] TimeSpan To
);