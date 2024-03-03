namespace Domain.Videos;

public sealed record VideoId(Guid Value)
{
    public static VideoId GenerateNew() => new(Guid.NewGuid());
}