using System.Collections.Generic;
using UnityEngine;

/// <summary> Class made to prevent DownloadBundleException when you try to download from the same link twice </summary>
public class BundleManager : MonoBehaviour 
{
    private List<AssetBundle> _bundles;
    private Dictionary<string, AnimationClip> _clips;

    // Format: {{base}}/info/songs/4/df919c856678c3ffe334-trainingAnimation3.COMO_PODE_UM_PEIXE_VIVO
    private string FindBundleNameInURL(string url)
    {
        string[] _ = url.Split('.');
        return _[_.Length - 1];
    }

    public AssetBundle GetByNameInUrl(string url)
    {
        string name = FindBundleNameInURL(url).ToUpper();

        if (_bundles != null)
        {
            for (int i = 0; i < _bundles.Count; i++)
            {
                if (_bundles[i].name.ToUpper() == name)
                    return _bundles[i];
            }
        }

        return null;
    }

    public bool HasStoraged(string url)
    {
        if(_clips != null)
        {
            if (_clips.TryGetValue(url, out _))
                return true;

            if(GetByNameInUrl(url) != null)
                return true;
        }

        return false;
    }

    public AnimationClip GetStoragedAnimation(string url)
    {
        _clips.TryGetValue(url, out AnimationClip value);
        value ??= BundleConversor.FromBundleToAnimationClip(GetByNameInUrl(url));

        return value;
    }

    public void StorageBundle(string url, AssetBundle bundle, AnimationClip clip)
    {
        Debug.Log("Salvando localmente dados do bundle " + bundle.name);

        if (_clips == null)
        {
            _clips = new Dictionary<string, AnimationClip>();
            _bundles = new List<AssetBundle>();
        }

        _bundles.Add(bundle);
        _clips.Add(url, clip);
    }

    private void OnDestroy()
    {
        if(_clips != null)
        {
            for (int i = _bundles.Count - 1; i >= 0; i--)
            {
                _bundles[i].Unload(false);
            }

            _bundles = null;
            _clips = null;
        }
    }
}