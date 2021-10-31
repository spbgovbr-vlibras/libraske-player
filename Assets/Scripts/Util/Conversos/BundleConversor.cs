using UnityEngine;
using UnityEngine.Networking;

public static class BundleConversor
{
    public static AssetBundle FromRequestToBundle(UnityWebRequest request)
    {
        return DownloadHandlerAssetBundle.GetContent(request);
    }

    public static AnimationClip FromRequestToAnimationClip(UnityWebRequest request, int desiredIndex = 0)
    {
        AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(request);
        return FromBundleToAnimationClip(bundle, desiredIndex);
    }

    public static AnimationClip FromBundleToAnimationClip(AssetBundle bundle, int desiredIndex = 0)
    {
        try
        {
            string bundleName = bundle.GetAllAssetNames()[desiredIndex];
            Debug.Log(bundle.LoadAsset(bundleName));
            AnimationClip clip = (AnimationClip)bundle.LoadAsset(bundleName);

            Debug.LogWarning("AnimationClip adquirido.");

            return clip;
        }
        catch
        {
            Debug.LogWarning("Erro ao adquirir AnimationClip.");
            return null;
        }
    }
}

