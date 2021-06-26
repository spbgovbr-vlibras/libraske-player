using UnityEngine;
using UnityEngine.UI;

public class InputFieldHandler : MonoBehaviour
{
    [SerializeField] private Text _inputField;
    [SerializeField] private Text _textToChange;

    public void ApplyText() => _textToChange.text = "E aí, " + _inputField.text;
}