using Infrastructure.Elasticsearch.Phrases;
using Infrastructure.Elasticsearch.Videos;
using Microsoft.Extensions.DependencyInjection;
using Nest;

namespace Infrastructure;

public static class ServiceCollectionExtensions
{
    public static void ConfigureInfrastructure(this IServiceCollection services)
    {
        services.ConfigureElasticsearch();
        services.AddSingleton<IPhraseRepository, PhraseRepository>();
        services.AddSingleton<IVideoRepository, VideoRepository>();
    }

    private static void ConfigureElasticsearch(this IServiceCollection services)
    {
        // TODO: add configuration
        var client = new ElasticClient(new Uri("http://localhost:9200"));
        services.AddSingleton<IElasticClient>(client);
    }
}