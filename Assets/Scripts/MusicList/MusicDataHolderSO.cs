using UnityEngine;


[CreateAssetMenu(fileName = "New Music Data Holder", menuName = "Libraske/Music/Music Data Holder")]
public class MusicDataHolderSO : ScriptableObject
{
    [SerializeField] private Music _music;

    private void OnEnable()
    {
        hideFlags = HideFlags.DontUnloadUnusedAsset;
    }

    public Music GetMusicData() => _music;
    public void SetMusicData(Music music) => _music = music;
}