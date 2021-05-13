using UnityEngine;

public class MusicSelection : MonoBehaviour
{
    [SerializeField] private MusicSO _musicChoosed;
    [SerializeField] private MusicSO[] _musics;
    [SerializeField] private MusicDisplay[] _displayers;

    [SerializeField] private GameObject _confirmMenu;

    private int _currentSelection;

    private void Start() => SetSelectionValue(0);

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            if (_currentSelection - 1 < 0)
                SetSelectionValue(_musics.Length - 1);
            else
                SetSelectionValue(_currentSelection - 1);
        }
        else if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            if (_currentSelection + 1 >= _musics.Length)
                SetSelectionValue(0);
            else
                SetSelectionValue(_currentSelection + 1);
        }

        if (Input.GetKeyUp(KeyCode.KeypadEnter) || Input.GetKeyUp(KeyCode.Return))
        {
            _musicChoosed.CopyDataTo(_musics[_currentSelection]);
            EnableConfirmMenu();
        }           
    }

    private void UpdateSelection()
    {
        int index = -1; // The middle display is the 0 index, because the selection is on it

        while(index < _displayers.Length - 1)
        {
            bool indexIsNegative = _currentSelection + index < 0;

            // Clamp values to a position in _musics array
            int value = indexIsNegative ? _musics.Length - 1 : (_currentSelection + index) % _musics.Length;

            _displayers[++index].SetMusic(_musics[value]);
        }
    }

    private void SetSelectionValue(int value)
    {
        _currentSelection = value;
        UpdateSelection();
    }

    public void EnableConfirmMenu()
    {
        if(_confirmMenu.GetComponentInChildren<MusicDisplay>() is MusicDisplay md)
            md.SetMusic(_musics[_currentSelection]);

        _confirmMenu.SetActive(true);

        transform.parent.gameObject.SetActive(false);
    }
}