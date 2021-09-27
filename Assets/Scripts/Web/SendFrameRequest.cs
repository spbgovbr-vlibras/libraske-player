using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class SendFrameRequest : MonoBehaviour
{
    //[SerializeField] private MusicSO _musicSelected;
    [SerializeField] private WebCamHandler _webcam;

    private int _currentRequest;
    private int _idSession = 10;

    private Coroutine _sendDataCoroutine;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (_sendDataCoroutine != null)
                StopCoroutine(_sendDataCoroutine);

            _sendDataCoroutine = StartCoroutine(SendDataCoroutine());
        }      
    }

    IEnumerator SendDataCoroutine()
    {
        Debug.Log("Solicitou requisição");

        var image = _webcam.GetImageInBytes();

        var www = WebRequest.SendFrame(_currentRequest, image, _idSession.ToString(), "/" + AccessSetup.AccessToken);

        yield return www.SendWebRequest();

        Debug.Log(www.url);

        if (www.result != UnityWebRequest.Result.Success)
            Debug.Log(www.error);
        else
        {
            _currentRequest++;
            Debug.Log("Form upload complete!");
        }
    }
}