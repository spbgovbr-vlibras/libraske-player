using Lavid.Libraske.UI;
using UnityEngine;

[RequireComponent(typeof(TextOverflowHandler))]
public class MusicDisplay : MonoBehaviour
{
    [SerializeField] private RequestImageFromURL _image;
    [SerializeField] private TextUI _name;
    [SerializeField] private TextUI _singers;
    [SerializeField] private TextUI _description;

    [Header("Selected Music"), Space(5)]
    [Tooltip("Apply music to ScrpitableObject to pass informations to others scenes.")]
    [SerializeField] private MusicDataHolderSO _dataHolder;
    [SerializeField] private MusicMediaHolderSO _mediaHolder;

    [Header("When Outside View")]
    [SerializeField] private GameObject _outsideScreenHover;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private float _opacityWhenOnScreen;
    [SerializeField] private float _opacityOutsideScreen;

    private Music _myMusic; // Music that this display shows

    public void IsInteractable(bool canInteract)
    {
        _outsideScreenHover.SetActive(!canInteract);
        _canvasGroup.blocksRaycasts = canInteract;
        _canvasGroup.interactable = canInteract;
        _canvasGroup.alpha = canInteract ? _opacityWhenOnScreen : _opacityOutsideScreen;
    }

    public void SetDataFromHolder(MusicDataHolderSO holder)
    {
        Music music = holder.GetMusicData();
        SetData(music.Name, music.Singers, music.Description, _mediaHolder.Thumbnail);
    }

    public void SetDataFromMusic(Music music) 
    {
        _myMusic = music;
        SetData(music.Name, music.Singers, music.Description, music.ThumbnailURL);
    }

    public void ApplyMyDataOnMusicHolder()
    {
        if (_dataHolder != null)
        {
            _dataHolder.SetMusicData(_myMusic);
            _mediaHolder.SetThumbnail(_image.GetRawImage());
        }
    }

    private void SetData(string name, string singers, string description, string imageURL)
    {
        if (_image != null)
        {
            _image.SetImageFrom(imageURL);
        }          

        if(_name != null)
            _name.SetText(name);

        if (_singers != null)
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
            _name.SetText(name);

        if (_singers != null)
            _singers.SetText(singers);

        if (_description != null)
            _description.SetText(description);
    }
}
