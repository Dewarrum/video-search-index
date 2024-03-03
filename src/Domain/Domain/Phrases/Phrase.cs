namespace Domain.Phrases;

public sealed class Phrase
{
    public Phrase(
        PhraseText text,
        PhraseTiming timing)
    {
        Text = text;
        Timing = timing;
    }

    public PhraseText Text { get; }
    public PhraseTiming Timing { get; }
}