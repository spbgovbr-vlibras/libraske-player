using Lavid.Libraske.Subtitles;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Subtitle
{
    int _pivotIndex;

    public Subtitle(Queue<SubtitleLine> queue) 
    {
        _lines = new List<SubtitleLine>();

        while (queue.Count > 0)
            _lines.Add(queue.Dequeue());

        _pivotIndex = -1;
    }
    public Subtitle(Subtitle other)
    {
        _lines = new List<SubtitleLine>();

        while (other.HasNextLine())
            _lines.Add(other.GetNextLine());

        _pivotIndex = -1;
    }

    private List<SubtitleLine> _lines;
    public bool HasNextLine() => _pivotIndex < _lines.Count - 1;
    public SubtitleLine GetNextLine() => _lines[++_pivotIndex];
}