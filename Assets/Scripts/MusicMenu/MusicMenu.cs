using Lavid.Libraske.DataStruct;
using Lavid.Libraske.UI;
using UnityEngine;

public class MusicMenu : MonoBehaviour
{
    [SerializeField] private GameObject _displayToInstance;
    [SerializeField] private Vector2 _initialPosition;
    [SerializeField] private float _xOffset;

    [Header("Texts")]
    [SerializeField] private TextUI _quantity;
    [SerializeField] private TextUI _quantityAndName;

    private Wrapper<Music> _songs;

    private void UpdateTexts()
    {
        int quantUnlocked = 1;
        int quantMax = _songs.Length;
        _quantity.SetText($"{quantUnlocked}/{quantMax}");
        _quantityAndName.SetText($"Minhas Músicas ({quantUnlocked})");
    }

    public void SetMusics(Wrapper<Music> songs)
    {
        _songs = songs;
        float x = _initialPosition.x;

        //_displayToInstance.transform.GetComponent<MusicDisplay>().SetDataFromMusic(songs[0]);
        //_displayToInstance.gameObject.SetActive(true);

        for (int i = 0; i < _songs.Length; i++)
        {
            x += i * _xOffset;
            var obj = Instantiate(_displayToInstance, transform);
            obj.transform.localPosition = _initialPosition + new Vector2(i * _xOffset, 0);
            obj.gameObject.SetActive(true);
            obj.transform.GetComponent<MusicDisplay>().SetDataFromMusic(songs[i]);
        }

        UpdateTexts();
    }
}