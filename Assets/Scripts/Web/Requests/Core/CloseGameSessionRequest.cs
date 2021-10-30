using Lavid.Libraske.UI;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

internal struct CloseGameSessionWebData { public int credit; }

public class CloseGameSessionRequest : MonoBehaviour, ILoggable
{
    [SerializeField] TextUI _creditText;
    public string InLogName { get => "CloseGameSessionRequest"; }

    private void Start()
    {
        StartCoroutine(CloseSessionCoroutine());
    }

    IEnumerator CloseSessionCoroutine()
    {
        Logger.Log(this, "Solicitou requisição");
        var request = WebRequestFormater.Patch(WebConstants.URL.CloseSessionURL, $"/{CurrentGameSession.ID}");
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            var data = JsonUtility.FromJson<CloseGameSessionWebData>(request.downloadHandler.text);
            int delta = data.credit - CurrentGameSession.GetPontuation();
            _creditText.SetText(delta.ToString());
            Logger.Log(this, "Total points: " + request.downloadHandler.text);
        }
        else
        {
            Logger.Log(this, request.error);

            if (FindObjectOfType<ErrorSystem>() is ErrorSystem errorSystem)
                errorSystem.ThrowError(new InGameError(request.error));
        }
    }
}