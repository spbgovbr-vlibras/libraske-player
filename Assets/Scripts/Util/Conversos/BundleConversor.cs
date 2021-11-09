using System;
using UnityEngine;
using UnityEngine.Networking;

public static class BundleConversor
{
    public static AssetBundle FromRequestToBundle(UnityWebRequest request, BundleManager manager)
    {
        try
        {
            var bundle = DownloadHandlerAssetBundle.GetContent(request);
            return bundle;
        }
        catch
        {
            Debug.LogWarning("Chamou uma excessão");

            var bundle = manager.GetByNameInUrl(request.url);
            return bundle;
        }
        //return DownloadHandlerAssetBundle.GetContent(request);
    }

    public static AnimationClip FromRequestToAnimationClip(UnityWebRequest request, BundleManager manager, int desiredIndex = 0)
    {
        AssetBundle bundle;
        try
        {
            bundle = DownloadHandlerAssetBundle.GetContent(request);
        }
        catch
        {
            Debug.LogWarning("Chamou uma excessão ao adquirir bundle em " + request + ". Iniciando busca na cache.");
            bundle = manager.GetByNameInUrl(request.url);
        }

        //AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(request);
        return FromBundleToAnimationClip(bundle, desiredIndex);
    }

    public static AnimationClip FromBundleToAnimationClip(AssetBundle bundle, int desiredIndex = 0)
    {
        try
        {
            string bundleName = bundle.GetAllAssetNames()[desiredIndex];
            AnimationClip clip = (AnimationClip)bundle.LoadAsset(bundleName);

            Debug.LogWarning("AnimationClip adquirido do bundle: " + bundle);

            return clip;
        }
        catch
        {
            Debug.LogWarning("Erro ao adquirir AnimationClip.");
            return null;
        }
    }
}