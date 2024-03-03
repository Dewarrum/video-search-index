using Domain.Phrases;

namespace Domain.Videos;

public sealed class Video
{
    private readonly List<Phrase> _phrases;

    public Video(
        VideoId id,
        VideoSource videoSource,
        IEnumerable<Phrase> phrases)
    {
        Id = id;
        VideoSource = videoSource;
        _phrases = phrases.ToList();
    }

    public Video(VideoSource videoSource)
    {
        Id = VideoId.GenerateNew();
        VideoSource = videoSource;
        _phrases = new List<Phrase>();
    }

    public VideoId Id { get; }
    public VideoSource VideoSource { get; }
    public IReadOnlyList<Phrase> Phrases => _phrases;

    public void AddPhrase(Phrase phrase) => _phrases.Add(phrase);
}