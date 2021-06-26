using Lavid.Libraske.Subtitle;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Subtitle : MonoBehaviour
{
    // Variables
    [SerializeField] private string _folderName;
    [SerializeField] private string _fileName;

    private const string FileExtension = ".lsrt";

    private Queue<SubtitleLine> _lineQueue;

    public bool HasNextLine() => _lineQueue.Count > 0;
    public SubtitleLine GetNextLine() => _lineQueue.Dequeue();

    private void Awake() =>_lineQueue = ReadFromFile();

    private Queue<SubtitleLine> ReadFromFile()
    {
        Queue <SubtitleLine> tempQueue = new Queue<SubtitleLine>();

        string fullFilePath = _folderName + "/" + _fileName;

        var mytxtData = Resources.Load<TextAsset>(fullFilePath);

        string[] lines = mytxtData.text.Split('\n');

        SubtitleLine line;

        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].Contains("#"))
            {
                line = new SubtitleLine(new SubtitleInterval(lines[i]), null);
                string sentence = lines[++i]; // line after time interval
                line.SetText(sentence);
                tempQueue.Enqueue(line);
            }
        }

        return tempQueue;
    }
}