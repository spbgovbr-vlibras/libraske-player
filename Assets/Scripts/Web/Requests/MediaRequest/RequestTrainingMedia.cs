using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class RequestTrainingMedia : WebRequest
{
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
            es.ThrowError(ErrorList.CastMusicListError);

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
                            : BundleConversor.FromRequestToAnimationClip(request, _bundleManager);

        return clip;
    }

    public override IEnumerator SendRequest()
    {
        int trainingSteps = TrainingController.TrainingStepsQuantity;

        _trainingAnimations = new AvatarAnimation[trainingSteps];
        UnityWebRequest request = null;

        for (int i = 0; i < trainingSteps; i++)
        {
            string url = _musicDataHolder.GetMusicData().GetTrainingAnimationURL(i);
            request = WebRequestFormater.GetBundle(url);
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                TryResendFailedRequest(request);
                yield break;
            }           

            AnimationClip clip = GetClip(url, request);
            Logger.Log(this, "got " + clip);
            _trainingAnimations[i] = new AvatarAnimation(clip);

            if(!_bundleManager.HasStoraged(url))
                _bundleManager.StorageBundle(request.url, BundleConversor.FromRequestToBundle(request, _bundleManager), clip);
        }

        OnRequestSuccess(request);
    }
}