using Nest;
using Language = Domain.Language;

namespace Infrastructure.Elasticsearch.Phrases;

public sealed record PhraseDbo(
    [property: Keyword(Name = "id")] string Id,
    [property: Text(Name = "text")] string Text,
    [property: Keyword(Name = "language")] Language Language,
    [property: Object(Name = "timings", Enabled = false)]
    PhraseTimingsDbo Timings
);