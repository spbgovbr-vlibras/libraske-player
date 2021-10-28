using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class MusicMedia
{
    [SerializeField] private Optional<AvatarAnimation> _musicAnimation;
    [SerializeField] private Optional<AvatarAnimation[]> _trainingAnimations;
    [SerializeField] private Optional<Subtitle> _subtitle;
    [SerializeField] private RawImage _thumbnail;

    #region Gets
    public AvatarAnimation MusicAnimation => _musicAnimation.Value;
    public AvatarAnimation[] TrainingAnimations => _trainingAnimations.Value;
    public Subtitle Subtitle => _subtitle.Value;
    public Texture Thumbnail => _thumbnail.texture;
    #endregion

    #region Sets
    public void SetMusicAnimation(AvatarAnimation animation) => _musicAnimation = new Optional<AvatarAnimation>(animation);
    public void SetTrainingAnimation(AvatarAnimation[] animations) => _trainingAnimations = new Optional<AvatarAnimation[]>(animations);
    public void SetSubtitle(Subtitle subtitle) => _subtitle = new Optional<Subtitle>(subtitle);
    public void SetThumbnail(RawImage rawImage) => _thumbnail = rawImage;
    #endregion

    /// <returns>returns if subtitle and all animations is initializated.</returns>
    public bool ReadyToPlay()
    {
        return _musicAnimation.IsEnabled && _trainingAnimations.IsEnabled && _subtitle.IsEnabled;
    }

    public void DiscardMedia()
    {
        _subtitle.DiscardValue();
        _musicAnimation.DiscardValue();
        _trainingAnimations.DiscardValue();
        _thumbnail = null;
    }
}