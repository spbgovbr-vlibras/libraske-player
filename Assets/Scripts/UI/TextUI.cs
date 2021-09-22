using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Lavid.Libraske.UI
{
    public class TextUI : MonoBehaviour
    {
        [Header("Text Type")]
        [Tooltip("Assign the right text type and let the other as null.")] [SerializeField] private TextMeshPro _textMeshPro;
        [Tooltip("Assign the right text type and let the other as null.")] [SerializeField] private TextMeshProUGUI _textMeshProUGUI;
        [Tooltip("Assign the right text type and let the other as null.")] [SerializeField] private Text _text;

        private string _value;

        public void ResetText() => SetText("");

        public string GetText() => _value;

        public void AddLetter(char letter) => SetText(_value + letter);

        public void SetText(string value)
        {
            if (_textMeshPro != null)
                _textMeshPro.text = value;
            else if (_text != null)
                _text.text = value;
            else if (_textMeshProUGUI != null)
                _textMeshProUGUI.text = value;

            _value = value;
        }

        public void SetFontSize(float value)
        {
            if (_textMeshPro != null)
                _textMeshPro.fontSize = value;
            else if (_text != null)
                _text.fontSize = (int) value;
            else if (_textMeshProUGUI != null)
                _textMeshProUGUI.fontSize = value;
        }

        public void SetColor(Color color)
        {
            if (_textMeshPro != null)
                _textMeshPro.color = color;
            else if (_text != null)
                _text.color = color;
            else if (_textMeshProUGUI != null)
                _textMeshProUGUI.color = color;
        }
    }
}