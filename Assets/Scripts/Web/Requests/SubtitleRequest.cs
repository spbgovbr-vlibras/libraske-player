using Lavid.Libraske.Subtitles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SubtitleRequest : MonoBehaviour, ILoggable
{
    public string urlDebug;
    [SerializeField] MusicHolderSO _musicHolder;
    [SerializeField] SubtitleReader _subtitleReader;
    public string InLogName => "SubtitleRequest";

    private void Awake() => StartCoroutine(ReadFromWeb());

    private IEnumerator ReadFromWeb()
    {
        var url = urlDebug;// _musicHolder.GetMusic().Subtitle;
        var request = WebRequestFormater.Get(url);
        yield return request.SendWebRequest();

        bool requestFailed = (request.result != UnityWebRequest.Result.Success);// || request.downloadHandler.error != null;

        if (requestFailed)
        {
            Debug.Log(request.downloadHandler.error);

            if (FindObjectOfType<ErrorSystem>() is ErrorSystem es)
                es.ThrowError(ErrorList.SubtitleDownloadError);
        }
        else
        {
            string data = request.downloadHandler.text;
            Logger.Log(this, "Subtitle Donwloaded.");

            Queue<SubtitleLine> lineQueue = StringToSubtitleLines(data);
            Subtitle subs = new Subtitle(lineQueue);

            _subtitleReader.StartReading(subs);
        }
    }

    private Queue<SubtitleLine> StringToSubtitleLines(string data)
    {
        string[] lines = data.Split('\n');
        Queue<SubtitleLine> tempQueue = new Queue<SubtitleLine>();

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