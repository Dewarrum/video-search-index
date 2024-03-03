using Nest;

namespace Infrastructure.Elasticsearch.Videos;

public sealed record VideoDbo(
    [property: Keyword(Name = "id")] string Id,
    [property: Text(Name = "title")] string Title,
    [property: Keyword(Name = "uri")] string Uri,
    [property: Number(Name = "seriesNumber")]
    int? SeriesNumber
);