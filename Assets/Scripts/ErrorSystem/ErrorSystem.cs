using Lavid.Libraske.UI;
using UnityEngine;

public class ErrorSystem : MonoBehaviour
{
    [SerializeField] GameObject _errorContainer;
    [SerializeField] TextUI _erroMsgText;
    [SerializeField] TextUI _erroCodeText;

    public void ThrowError(InGameError err)
    {
        _errorContainer.SetActive(true);

        if (_erroMsgText != null)
            _erroMsgText.SetText(err.Message);

        if (_erroCodeText != null)
        {
            string code = err.HasCode() ? err.Code.ToString() : "";
            _erroMsgText.SetText(code);
        }
    }
}
