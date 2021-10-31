using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class RequestTrainingMedia : WebRequest
{
    private const int TrainingSteps = 5;

    [SerializeField] private MusicDataHolderSO _musicDataHolder;
    [SerializeField] private MusicMediaHolderSO _musicMediaHolder;
    [SerializeField] private BundleManager _bundleManager;

    private AvatarAnimation[] _trainingAnimations;

    public override string GetLogName() => "RequestTrainingMedia";

    private void Start() => StartCoroutine(SendRequest());

    protected override void OnRequestError(UnityWebRequest request)
    {
        PrintFailText(request);

        if (FindObjectOfType<ErrorSystem>() is ErrorSystem es)
            es.ThrowError(ErrorList.CastError);

        InvokeOnErrorEvent();
    }

    protected override void OnRequestSuccess(UnityWebRequest request)
    {
        _requestWasSuccess = true;
        PrintSuccessText(request);
        _musicMediaHolder.TrainingAnimations = _trainingAnimations;
        InvokeOnSuccessEvent();
    }

    private AnimationClip GetClip(string url, UnityWebRequest request)
    {
        AnimationClip clip = _bundleManager.HasStoraged(url)
                            ? _bundleManager.GetStoragedAnimation(url)
                            : BundleConversor.FromRequestToAnimationClip(request);

        return clip;
    }

    protected override IEnumerator SendRequest()
    {
        _trainingAnimations = new AvatarAnimation[TrainingSteps];
        UnityWebRequest request = null;

        for (int i = 0; i < TrainingSteps; i++)
        {
            string url = _musicDataHolder.GetMusicData().GetTrainingAnimationURL(i);
            request = WebRequestFormater.GetBundle(url);
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                OnRequestError(request);
                StopCoroutine(SendRequest());
            }           

            AnimationClip clip = GetClip(url, request);
            Debug.Log(clip);
            _trainingAnimations[i] = new AvatarAnimation(clip);

            if(!_bundleManager.HasStoraged(url))
                _bundleManager.StorageBundle(request.url, BundleConversor.FromRequestToBundle(request), clip);
        }

        OnRequestSuccess(request);
    }
}