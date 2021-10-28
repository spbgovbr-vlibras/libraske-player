using Lavid.Libraske.DataStruct;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(GetBundleRequest))]
public abstract class InGameController : MonoBehaviour
{
    [SerializeField] protected MusicHolderSO _musicHolder;
    [SerializeField] protected AvatarAnimationController _avatarAnimators;
    [SerializeField] protected GetBundleRequest _bundleRequest;
    [SerializeField] protected Wrapper<AssetBundle> _bundlesDownloadeds;

    public abstract IEnumerator SetupAnimations();

    protected void AddBundleDownloaded(AssetBundle bundle)
    {
        if (_bundlesDownloadeds == null)
            _bundlesDownloadeds = new Wrapper<AssetBundle>();

        _bundlesDownloadeds.Add(bundle);
    }

    protected virtual void OnDestroy()
    {
        if(_bundlesDownloadeds != null)
        {
            for(int i = _bundlesDownloadeds.Length-1; i >= 0; i--)
            {
                _bundlesDownloadeds[i].Unload(true);
                _bundlesDownloadeds[i] = null;
            }
        }
    }
}
