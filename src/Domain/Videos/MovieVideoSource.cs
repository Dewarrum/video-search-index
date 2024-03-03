namespace Domain.Videos;

public sealed record MovieVideoSource(
    string Title,
    Uri Uri
) : VideoSource(Title, Uri);