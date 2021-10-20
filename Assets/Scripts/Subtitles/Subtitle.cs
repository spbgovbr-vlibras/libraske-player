using Lavid.Libraske.Subtitle;
using System.Collections.Generic;

[System.Serializable]
public struct Subtitle
{
    public Subtitle(Queue<SubtitleLine> lines) => _lines = lines;

    private Queue<SubtitleLine> _lines;
    public bool HasNextLine() => _lines.Count > 0;
    public SubtitleLine GetNextLine() => _lines.Dequeue();
}