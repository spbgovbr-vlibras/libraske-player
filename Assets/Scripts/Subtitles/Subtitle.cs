using Lavid.Libraske.Subtitle;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Subtitle : MonoBehaviour
{
    // Variables
    [SerializeField] private string _folderName = "Musics/falcon";
    [SerializeField] private string _FileName = "falcon.src";

    private Queue<SubtitleLine> _lineQueue;

    public bool HasNextLine() => _lineQueue.Count >= 1;
    public SubtitleLine GetNextLine() => _lineQueue.Dequeue();

    private void Awake() =>_lineQueue = ReadFromFile();

    private Queue<SubtitleLine> ReadFromFile()
    {
        Queue <SubtitleLine> tempQueue = new Queue<SubtitleLine>();

        string fullFilePath = Path.Combine(Application.dataPath, _folderName, _FileName);

        string[] lines = File.ReadAllLines(fullFilePath);

        SubtitleLine line = null;

        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].Contains("#"))
            {
                line = new SubtitleLine(new SubtitleInterval(lines[i]), null);
            }

            if (lines[i].Contains("\""))
            {
                string sentence = lines[i].Replace("\"", "");
                line.SetText(sentence);
                tempQueue.Enqueue(line);
            }
        }

        return tempQueue;
    }
}