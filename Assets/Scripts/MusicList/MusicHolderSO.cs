using UnityEngine;


[CreateAssetMenu(fileName = "New Music Holder", menuName = "Libraske/Music/MusicHolder")]
public class MusicHolderSO : ScriptableObject
{
    [SerializeField] private Music _music;
    [SerializeField] private MusicMedia _musicMedia;

    public Music GetMusicData() => _music;
    public void SetMusicData(Music music) => _music = music;

    public MusicMedia Media => _musicMedia;
}