using Lavid.Libraske.UI;
using Lavid.Libraske.Web;
using UnityEngine;

public class UserNameHandler : MonoBehaviour
{
    [SerializeField, TextArea(5, 10)] string _beforeName;
    [SerializeField, TextArea(5, 10)] string _afterName;
    [SerializeField] TextUI _text;

    private void OnEnable() => UpdateText();

    public void UpdateText()
    {
        if (_text != null)
            _text.SetText(_beforeName + AccessData.UserName + _afterName);
    }
}
