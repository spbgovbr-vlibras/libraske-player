using UnityEngine;

public class MusicSelection2 : MonoBehaviour, ISelectionObserver
{
    [SerializeField] private MusicSO[] _musics;
    [SerializeField] private MusicDisplay[] _displayers;
    [SerializeField] private SelectionController _controller;

    private int _currentSelection;

    public int GetMaxValue() => (int) _controller.GetClampedValue().GetMaxValue();
    public MusicSO GetMusic(int position) => _musics[position];

    private void Start()
    {
        _controller.AddObserver(this);

        for (int i = 0; i < _displayers.Length; i++)
        {
            _displayers[i].SetMusic(_musics[i]);
            _displayers[i].SetCurrentSelection(i);
        }
    }

    public void UpdateSelectionValue(int newValue)
    {
        bool isIncreasing = newValue >= 4 && _currentSelection < newValue;
        bool isDecreasing = newValue <= 4 && _currentSelection >= 4;

        if (isIncreasing)
        {
            for (int i = 0; i < _displayers.Length; i++)
            {
                _displayers[i].Increase();
            }
        }
        else if (isDecreasing)
        {
            for (int i = 0; i < _displayers.Length; i++)
            {
                _displayers[i].Decrease();
            }
        }

        _currentSelection = newValue;
    }
}