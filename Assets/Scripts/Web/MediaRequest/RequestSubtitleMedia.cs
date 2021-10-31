using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class RequestSubtitleMedia : WebRequest
{
    [SerializeField] private MusicDataHolderSO _musicDataHolder;
    [SerializeField] private MusicMediaHolderSO _musicMediaHolder;

    public override string GetLogName() => "RequestSubtitleMedia";

    private void Start() => StartCoroutine(SendRequest());

    protected override void OnRequestError(UnityWebRequest request)
    {
        PrintFailText(request);

        if (FindObjectOfType<ErrorSystem>() is ErrorSystem es)
            es.ThrowError(ErrorList.SubtitleDownloadError);

        InvokeOnErrorEvent();
    }

    protected override void OnRequestSuccess(UnityWebRequest request)
    {
        Subtitle subtitle = SubtitleConversor.FromRequestToSubtitle(request);
        _musicMediaHolder.Subtitle = subtitle;
        PrintSuccessText(request);
        _requestWasSuccess = true;
        InvokeOnSuccessEvent();
    }

    protected override IEnumerator SendRequest()
    {
        string url = _musicDataHolder.GetMusicData().SubtitleURL;
        var request = WebRequestFormater.Get(url);
        yield return request.SendWebRequest();
        VerifyRequest(request);
    }
}