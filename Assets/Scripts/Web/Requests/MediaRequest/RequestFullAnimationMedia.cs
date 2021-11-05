using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class RequestFullAnimationMedia : WebRequest
{
    [SerializeField] private MusicDataHolderSO _musicDataHolder;
    [SerializeField] private MusicMediaHolderSO _musicMediaHolder;   
    [SerializeField] private BundleManager _bundleManager;

    public override string GetLogName() => "RequestAnimationMedia";

    private void Start() => StartCoroutine(SendRequest());

    protected override void OnRequestError(UnityWebRequest request)
    {
        PrintFailText(request);

        if (FindObjectOfType<ErrorSystem>() is ErrorSystem es)
            es.ThrowError(ErrorList.CastMusicListError);

        InvokeOnErrorEvent();
    }

    private AnimationClip GetClip(string url, UnityWebRequest request)
    {
        AnimationClip clip = _bundleManager.HasStoraged(url)
                            ? _bundleManager.GetStoragedAnimation(url)
                            : BundleConversor.FromRequestToAnimationClip(request);

        return clip;
    }

    protected override void OnRequestSuccess(UnityWebRequest request)
    {
        _requestWasSuccess = true;

        PrintSuccessText(request);

        string url = request.url;

        AnimationClip clip = GetClip(url, request);
        AvatarAnimation anim = new AvatarAnimation(clip);
        _musicMediaHolder.MusicAnimation = anim;

        if(!_bundleManager.HasStoraged(url))
            _bundleManager.StorageBundle(url, BundleConversor.FromRequestToBundle(request), clip);

        InvokeOnSuccessEvent();
    }

    public override IEnumerator SendRequest()
    {
        string url = _musicDataHolder.GetMusicData().FullAnimationURL;
        var request = WebRequestFormater.GetBundle(url);

        yield return request.SendWebRequest();

        VerifyRequest(request);
    }
}