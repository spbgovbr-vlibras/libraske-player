using Lavid.Libraske.Avatar;
using Lavid.Libraske.DataStruct;
using UnityEngine;

/// <summary> A color arrangement to manage the colors handlers. </summary>
public class ColorSet : MonoBehaviour
{
    [SerializeField] private GameObject _unlockButton;
    [SerializeField] private Wrapper<CustomizationColorHandler> _colorHandlers;
    [SerializeField] private bool _startLocked;

    private void OnEnable()
    {
        _unlockButton.SetActive(_startLocked);

        for (int i = 0; i < _colorHandlers.Length; i++)
            _colorHandlers[i].LockColor(_startLocked);
    }
}