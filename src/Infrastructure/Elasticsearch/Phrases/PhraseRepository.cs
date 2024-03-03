using Nest;
using Serilog;

namespace Infrastructure.Elasticsearch.Phrases;

public sealed class PhraseRepository : IPhraseRepository
{
    private static readonly IndexName IndexName = "phrases";

    private readonly IElasticClient _client;
    private readonly ILogger _logger;

    public PhraseRepository(IElasticClient client, ILogger logger)
    {
        _client = client;
        _logger = logger;
    }

    public async Task Save(IReadOnlyList<PhraseDbo> phrases, CancellationToken cancellationToken = default)
    {
        var response = await _client.IndexManyAsync(phrases, IndexName, cancellationToken);
        if (response.Errors)
            _logger.Error(response.OriginalException, "An error occurred while saving phrases");

        foreach (var phrase in phrases)
        {
            _logger.Information("Phrase '{PhraseId}' has been successfully saved", phrase.Id);
        }
    }
}