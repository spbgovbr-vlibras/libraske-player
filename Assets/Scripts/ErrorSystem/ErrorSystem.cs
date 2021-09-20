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
            string codeText = "";

            if (err.HasCode())
                codeText = $"Erro {err.Code}";

            _erroMsgText.SetText(codeText);
        }
    }
}
