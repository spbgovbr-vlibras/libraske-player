using Lavid.Libraske.UI;
using UnityEngine;

public class MusicDisplay : MonoBehaviour
{
    [SerializeField] private URLImage _image;
    [SerializeField] private TextUI _name;
    [SerializeField] private TextUI _singers;
    [SerializeField] private TextUI _description;

    [Header("Overflow Handler")]
    [SerializeField] private bool _filterNameOverflow;
    [SerializeField, Range(0, 18)] private int _maxNameCharacters = 15;

    private Music _currentMusic;
    public Music GetCurrentMusic() => _currentMusic;

    public void SetDataFromDisplay(MusicDisplay display) => SetDataFromMusic(display.GetCurrentMusic());

    public void SetDataFromMusic(Music music) 
    {
        if(music != _currentMusic)
            SetData(music.Name, music.Singers, music.Description, music.Thumbnail);

        _currentMusic = music;
    }

    private void SetData(string name, string singers, string description, string imageURL)
    {
        if (_image != null)
        {
            _image.SetImageFrom(imageURL);
        }          

        if(_name != null)
        {
            if(_filterNameOverflow)
                _name.SetText(OverflowFilter(name));
            else
                _name.SetText(name);
        }
            
        if(_singers != null)
            _singers.SetText(singers);

        if(_description != null)
            _description.SetText(description);
    }

    /// <returns> Returns wrapped text with ellipsis.</returns>
    private string OverflowFilter(string input)
    {
        var output = input;

        if (input.Length >= _maxNameCharacters)
        {
            output = output.Remove(_maxNameCharacters - 1);
            output += "...";
        }

        return output;
    }
}
