using Lavid.Libraske.DataStruct;
using Lavid.Libraske.UI;
using UnityEngine;
using System;

public class MusicMenu : MonoBehaviour
{
    [Header("Music Instance")]
    [SerializeField] private GameObject _displayToInstance;
    [SerializeField] private Vector2 _initialPosition;
    [SerializeField] private float _xOffset;
    [SerializeField] private MusicMenuSlider _musicListParent;

    [Header("Texts")]
    [SerializeField] private TextUI _quantity;
    [SerializeField] private TextUI _quantityAndName;

    private Wrapper<Music> _songs;

    public float OffsetBetweenDisplays => _xOffset;

    private void UpdateTexts()
    {
        int quantUnlocked = 0;
        for (int i = 0; i < _songs.Length; i++)
        {
            Music song = _songs[i];
            if (song.IsUnlocked)
                quantUnlocked++;
        }

        int quantMax = _songs.Length;
        _quantity.SetText($"{quantUnlocked}/{quantMax}");
        _quantityAndName.SetText($"Minhas Músicas ({quantUnlocked})");
    }

    public void SetMusics(Wrapper<Music> songs)
    {
        _songs = songs;

        Instantiate(songs, _initialPosition.x);

        UpdateTexts();
    }

    private void Instantiate(Wrapper<Music> songs, float inititalPosition)
    {
        for (int i = 0; i < _songs.Length; i++)
        {
            inititalPosition += i * _xOffset;
            var obj = Instantiate(_displayToInstance, _musicListParent.transform);
            obj.transform.localPosition = _initialPosition + new Vector2(i * _xOffset, 0);
            obj.gameObject.SetActive(true);

            var display = obj.transform.GetComponent<MusicDisplay>();
            display.SetDataFromMusic(songs[i]);
            _musicListParent.AddDisplay(display);
        }
    }
}
