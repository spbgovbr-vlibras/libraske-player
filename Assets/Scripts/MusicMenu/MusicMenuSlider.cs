using Lavid.Libraske.DataStruct;
using UnityEngine;

public class MusicMenuSlider : MonoBehaviour 
{
    [SerializeField] MusicMenu _musicMenu;
    private Wrapper<MusicDisplay> _displays;

    public int _minQuantityOnScreen = 5;
    public int _maxQuantityInteractable = 4;
    public int _lastDisplayOnScreenIndex;

    [Header("Buttons")]
    [SerializeField] GameObject _buttonNext;
    [SerializeField] GameObject _buttonPrevious;

    private void Start()
    {
        UpdateInteractables();
        UpdateButtons();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.RightArrow))
            ShowNext(); 

        if (Input.GetKeyUp(KeyCode.LeftArrow))
            ShowPrevious();
    }

    public void AddDisplay(MusicDisplay display)
    {
        if (_displays == null)
            _displays = new Wrapper<MusicDisplay>();

        _displays.Add(display);
        _lastDisplayOnScreenIndex = _minQuantityOnScreen;

        UpdateInteractables();
        UpdateButtons();
    }

    private bool IsShowingFirstSong() => _lastDisplayOnScreenIndex - _minQuantityOnScreen <= 0;
    private bool IsShowingLastSong() => _displays != null && _lastDisplayOnScreenIndex >= _displays.Length;
    
    private void UpdateButtons()
    {
        _buttonNext.SetActive(!IsShowingLastSong());
        _buttonPrevious.SetActive(!IsShowingFirstSong());
    }

    public void ShowNext()
    {
        if (IsShowingLastSong())
            return;

        MoveAllDisplays(new Vector3(-_musicMenu.OffsetBetweenDisplays, 0, 0));
        _lastDisplayOnScreenIndex++;

        UpdateInteractables();
        UpdateButtons();
    }

    public void ShowPrevious()
    {
        if (IsShowingFirstSong())
            return;

        MoveAllDisplays(new Vector3(_musicMenu.OffsetBetweenDisplays, 0, 0));
        _lastDisplayOnScreenIndex--;

        UpdateInteractables();
        UpdateButtons();
    }

    private void MoveAllDisplays(Vector3 value)
    {
        if (_displays == null)
            return;

        for (int i = 0; i < _displays.Length; i++)
            _displays[i].transform.localPosition += value;
    }

    private void UpdateInteractables()
    {
        if (_displays == null)
            return;

        int end = _lastDisplayOnScreenIndex -1;
        int init = end - _maxQuantityInteractable;

        for (int i = 0; i < _displays.Length; i++)
        {
            bool shouldInteract = i >= init && i <= end;
            _displays[i].IsInteractable(shouldInteract);
        }
    }
}