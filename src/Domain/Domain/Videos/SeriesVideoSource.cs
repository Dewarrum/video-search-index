namespace Domain.Videos;

public sealed record SeriesVideoSource(
    string Title,
    Uri Uri,
    int SeriesNumber
) : VideoSource(Title, Uri);