namespace Domain.Videos;

public abstract record VideoSource(
    string Title,
    Uri Uri
);