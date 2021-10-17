using System.Collections;
using UnityEngine;

[RequireComponent(typeof(GetBundleRequest))]
public abstract class InGameController : MonoBehaviour
{
    [SerializeField] protected MusicHolderSO _musicHolder;
    [SerializeField] protected AvatarAnimationController _avatarAnimators;
    [SerializeField] protected GetBundleRequest _bundleRequest;

    public abstract IEnumerator SetupAnimations();
}
