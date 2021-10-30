using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Music Media Holder", menuName = "Libraske/Music/Music Media Holder")]
public class MusicMediaHolderSO : ScriptableObject
{
    [SerializeField] private AvatarAnimation _musicAnimation;
    [SerializeField] private AvatarAnimation[] _trainingAnimations;
    [SerializeField] private Subtitle _subtitle;
    [SerializeField] private AudioClip _musicAudio;
    [SerializeField] private RawImage _thumbnail;


    public AvatarAnimation MusicAnimation { get => _musicAnimation; set => _musicAnimation = value; }
    public AvatarAnimation[] TrainingAnimations { get => _trainingAnimations; set => _trainingAnimations = value; }
    public Subtitle Subtitle { get => _subtitle; set => _subtitle = value; }
    public AudioClip MusicAudio { get => _musicAudio; set => _musicAudio = value; }


    public Texture Thumbnail => _thumbnail.texture;
    public void SetThumbnail(RawImage rawImage) => _thumbnail = rawImage;

    //public void DiscardMedia()
    //{
    //    _subtitle.DiscardValue();
    //    _musicAnimation.DiscardValue();
    //    _trainingAnimations.DiscardValue();
    //    _musicAudio.DiscardValue();
    //    _thumbnail = null;
    //}
}