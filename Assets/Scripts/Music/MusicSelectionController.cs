using Lavid.Libraske.DataStruct;
using UnityEngine;

public class MusicSelectionController : MonoBehaviour, ISelectionObserver
{
    [SerializeField] Wrapper<MusicDisplay> _displays;
    [SerializeField] SelectionController _controller;

    private void ApplyDefaultSelection()
    {
        for (int i = 0; i < _displays.Length; i++)
            _displays.At(i).debugValue = i;
    }

    public void UpdateSelectionValue(int newValue)
    {
        if (newValue <= _displays.Length - 2)
        {
            ApplyDefaultSelection();
            return;
        }

        int displaysLength = _displays.Length;

        if (_controller.IsSelectingLastItem())
        {
            for (int i = displaysLength - 2; i >= 0; i--)
            {
                _displays.At(i).debugValue = newValue;
                newValue--;
            }

            return;
        }

        Debug.Log("aaa " + newValue);

        _displays.At(displaysLength - 1).debugValue = newValue + 1;

        for (int i = displaysLength - 2; i >= 0; i--)
        {
            _displays.At(i).debugValue = newValue;
            newValue--;
        }
    }
}
