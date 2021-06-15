using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class PontuationController : MonoBehaviour
{
    [SerializeField] GameSession _gameSession;

    private void Awake()
    {
        _gameSession.OnSetupFinished += Enable;
    }

    public void OnDestroy()
    {
        StopAllCoroutines();

        if (_gameSession != null)
            _gameSession.OnSetupFinished -= Enable;
    }

    private void Enable()
    {
        StartCoroutine(GetRequestCoroutine());
    }

    IEnumerator GetRequestCoroutine()
    {
        while (true)
        {
            var webRequest = WebRequest.Get(WebConstants.URL.PontuationURL, $"/{_gameSession.Id}");

            yield return webRequest.SendWebRequest();

            string pontuation = webRequest.downloadHandler.text.Split(':')[1];
            pontuation = pontuation.Substring(0, pontuation.Length - 1);

            Debug.Log("Pontuação: " + pontuation);

            yield return new WaitForSeconds(2);
        }

    }

}
