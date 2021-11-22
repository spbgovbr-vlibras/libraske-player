using Lavid.Libraske.DataStruct;
using Lavid.Libraske.Json;
using Lavid.Libraske.Web;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class RequestMusicList : WebRequest
{
    [SerializeField] private MusicMenu _musicMenu;
    [SerializeField] private Wrapper<Music> _songs;

    void OnEnable() => StartCoroutine(SendRequest());

    void OnDestroy() => StopAllCoroutines();

    public override string GetLogName() => "RequestMusics";
    protected override string SuccessText(UnityWebRequest request) => "Response: " + request.downloadHandler.text;

    protected override void OnRequestSuccess(UnityWebRequest request)
    {
        _requestWasSuccess = true;

        try
        {
            _songs = MusicConversor.FromRequestToMusicWrapper(request);
            _musicMenu.SetMusics(_songs);
            PrintSuccessText(request);
            InvokeOnSuccessEvent();
        }
        catch
        {
            if (FindObjectOfType<ErrorSystem>() is ErrorSystem es)
                es.ThrowError(ErrorList.CastMusicListError);

            Logger.LogError(this, "Houve um problema no cast de variáveis");
        }
    }
    protected override void OnRequestError(UnityWebRequest request)
    {
        PrintFailText(request);

        if (FindObjectOfType<ErrorSystem>() is ErrorSystem es)
            es.ThrowError(ErrorList.DownloadMusicListError);
    }

    public override IEnumerator SendRequest()
    {
        Logger.Log(this, "Solicitou requisição das músicas");
        var webRequest = WebRequestFormater.Get(WebConstants.URL.SongsURL);
        yield return webRequest.SendWebRequest();
        VerifyRequest(webRequest);
    }
}
