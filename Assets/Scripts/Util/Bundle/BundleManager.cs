using System.Collections.Generic;
using UnityEngine;

/// <summary> Class made to prevent DownloadBundleException when you try to download from the same link twice </summary>
public class BundleManager : MonoBehaviour 
{
    private List<AssetBundle> _bundles;
    private Dictionary<string, AnimationClip> _clips;

    public bool HasStoraged(string url)
    {
        if (_clips == null)
            return false;

        AnimationClip value;
        _clips.TryGetValue(url, out value);

        return value != null;
    }

    public AnimationClip GetStoragedAnimation(string url)
    {
        AnimationClip value;
        _clips.TryGetValue(url, out value);

        return value;
    }

    public void StorageBundle(string url, AssetBundle bundle, AnimationClip clip)
    {
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