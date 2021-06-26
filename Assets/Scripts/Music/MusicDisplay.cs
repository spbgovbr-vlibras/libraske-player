using UnityEngine;
using UnityEngine.UI;

public class MusicDisplay : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Text _name;
    [SerializeField] private Text _author;
    [SerializeField] private Text _duration;

    [SerializeField] private MusicSO _music;

    private int _currentSelection;

    public void SetCurrentSelection(int value) => _currentSelection = value;
    public void Increase() => _currentSelection++;
    public void Decrease() => _currentSelection--;

    private const string TextB4ShowDuration = "Duração: ";

    private void OnEnable()
    {
        if (_music != null)
            SetMusic(_music);
    }

    public void SetMusic(MusicSO music)
    {
        _music = music;

        _image.sprite = music.GetSprite();
        _name.text = music.GetName();
        _author.text = music.GetAuthor();
        _duration.text = TextB4ShowDuration + music.GetMinutesOfDuration() + ":" + music.GetSecondsOfDuration();
    }
}