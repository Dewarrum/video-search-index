using Infrastructure.Elasticsearch.Phrases;

namespace Infrastructure.Elasticsearch.Videos;

public interface IVideoRepository
{
    Task Save(
        VideoDbo video,
        IEnumerable<PhraseDbo> phrases,
        CancellationToken cancellationToken = default
    );
}