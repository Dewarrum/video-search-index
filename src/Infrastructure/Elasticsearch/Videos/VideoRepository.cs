using Infrastructure.Elasticsearch.Phrases;
using Nest;
using Serilog;

namespace Infrastructure.Elasticsearch.Videos;

internal sealed class VideoRepository : IVideoRepository
{
    private static readonly IndexName IndexName = "videos";

    private readonly IElasticClient _client;
    private readonly ILogger _logger;

    public VideoRepository(IElasticClient client, ILogger logger)
    {
        _client = client;
        _logger = logger;
    }

    public async Task Save(
        VideoDbo video,
        IEnumerable<PhraseDbo> phrases,
        CancellationToken cancellationToken = default)
    {
        var request = new IndexRequest<VideoDbo>(IndexName)
        {
            Document = video
        };
        var response = await _client.IndexAsync(request, cancellationToken);
        if (response.OriginalException is not null)
            _logger.Error(response.OriginalException, "An error occurred while saving vide");

        _logger.Information("Video '{VideoId}' has been successfully saved", video.Id);
    }
}