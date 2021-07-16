using Lavid.Libraske.UI;
using UnityEngine;
using UnityEngine.UI;

public class MusicDisplay : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TextUI _name;
    [SerializeField] private TextUI _author;
    [SerializeField] private TextUI _duration;

    public int debugValue;



    public void DisplayMusic(Song music)
    {
        //DisplayMusic(music.Thumbnail, music.Name, music.Singers, music.Description, music.Subtitle);
    }

    public void DisplayMusic(Image image, TextUI name, TextUI author, TextUI duration)
    {
        _image.sprite = image.sprite;
        _name.SetText(name.GetText());
        _author.SetText(author.GetText());
        _duration.SetText(duration.GetText());
    }
}