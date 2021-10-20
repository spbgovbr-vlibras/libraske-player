using Lavid.Libraske.UI;
using UnityEngine;

public class MusicDisplay : MonoBehaviour
{
    [SerializeField] private RequestImageFromURL _image;
    [SerializeField] private TextUI _name;
    [SerializeField] private TextUI _singers;
    [SerializeField] private TextUI _description;

    [Header("Overflow Handler")]
    [SerializeField] private bool _filterNameOverflow;
    [SerializeField, Range(0, 18)] private int _maxNameCharacters = 15;

    [Header("Selected Music"), Space(5)]
    [Tooltip("Apply music to ScrpitableObject to pass informations to others scenes.")]
    [SerializeField] 
    private MusicHolderSO _musicHolder;

    private Music _myMusic; // Music that this display shows

    public void SetDataFromHolder(MusicHolderSO holder)
    {
        Music music = holder.GetMusic();
        SetData(music.Name, music.Singers, music.Description, holder.GetThumbnail());
    }

    public void SetDataFromMusic(Music music) 
    {
        _myMusic = music;
        SetData(music.Name, music.Singers, music.Description, music.ThumbnailURL);
    }

    public void ApplyMyDataOnMusicHolder()
    {
        if (_musicHolder != null)
        {
            _musicHolder.SetMusic(_myMusic);
            _musicHolder.SetThumbnail(_image.GetRawImage());
        }
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
    private void SetData(string name, string singers, string description, Texture texture)
    {
        if (_image != null)
        {
            _image.SetTexture(texture);
        }

        if (_name != null)
        {
            if (_filterNameOverflow)
                _name.SetText(OverflowFilter(name));
            else
                _name.SetText(name);
        }

        if (_singers != null)
            _singers.SetText(singers);

        if (_description != null)
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
