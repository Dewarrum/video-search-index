namespace Domain.Phrases;

public sealed record PhraseTiming(
    TimeSpan From,
    TimeSpan To
);