using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class RequestMusicMedia : WebRequest
{
    [SerializeField] private MusicHolderSO _musicDataHolder;
    [SerializeField] private MusicMediaHolderSO _musicMediaHolder;

    public override string GetLogName() => "RequestMusicMedia";

    private void Start() => StartCoroutine(SendRequest());

    protected override void OnRequestError(UnityWebRequest request)
    {
        PrintFailText(request);

        if (FindObjectOfType<ErrorSystem>() is ErrorSystem es)
        {
            es.ThrowError(ErrorList.MusicDownloadError);
        }

        InvokeOnErrorEvent();
    }

    protected override void OnRequestSuccess(UnityWebRequest request)
    {
        _requestWasSuccess = true;
        AudioClip clip = DownloadHandlerAudioClip.GetContent(request);
        _musicMediaHolder.MusicAudio = clip;
        PrintSuccessText(request);
        InvokeOnSuccessEvent();
    }

    protected override IEnumerator SendRequest()
    {
        string url = _musicDataHolder.GetMusicData().MusicMediaURL;
        var request = WebRequestFormater.GetAudioClip(url);

        yield return request.SendWebRequest();

        VerifyRequest(request);
    }
}
