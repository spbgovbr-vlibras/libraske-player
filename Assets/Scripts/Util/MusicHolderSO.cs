using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Music Holder", menuName = "Libraske/Music/MusicHolder")]
public class MusicHolderSO : ScriptableObject
{
    [SerializeField] private RawImage _thumbnail;
    [SerializeField] private Music _music;

    public Music GetMusic() => _music;
    public void SetMusic(Music music) => _music = music;

    public Texture GetThumbnail() => _thumbnail.texture;
    public void SetThumbnail(RawImage rawImage) => _thumbnail = rawImage;
}