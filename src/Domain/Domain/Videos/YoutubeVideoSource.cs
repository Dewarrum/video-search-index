namespace Domain.Videos;

public sealed record YoutubeVideoSource(
    string Title,
    Uri Uri
) : VideoSource(Title, Uri);