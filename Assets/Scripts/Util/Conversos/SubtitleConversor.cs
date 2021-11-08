using Lavid.Libraske.Subtitles;
using System.Collections.Generic;
using UnityEngine.Networking;

public static class SubtitleConversor 
{
    public static Subtitle FromRequestToSubtitle(UnityWebRequest request)
    {
        string data = request.downloadHandler.text;
        return FromStringToSubtitle(data);
    }

    public static Subtitle FromStringToSubtitle(string data)
    {
        string[] linesString = data.Split('\n');
        Queue<SubtitleLine> tempQueue = new Queue<SubtitleLine>();

        for (int i = 0; i < linesString.Length; i++)
        {
            if (linesString[i].Contains("#"))
            {
                UnityEngine.Debug.Log(linesString[i]);
                var subtitleLine = new SubtitleLine(new SubtitleInterval(linesString[i]), null);
                string sentence = linesString[++i]; // line after time interval
                subtitleLine.SetText(sentence);
                tempQueue.Enqueue(subtitleLine);
            }
        }

        return new Subtitle(tempQueue);
    }
}