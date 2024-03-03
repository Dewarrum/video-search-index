namespace Infrastructure.Elasticsearch.Phrases;

public interface IPhraseRepository
{
    Task Save(IReadOnlyList<PhraseDbo> phrases, CancellationToken cancellationToken = default);
}