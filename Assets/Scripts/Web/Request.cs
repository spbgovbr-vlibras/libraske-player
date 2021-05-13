using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class Request : MonoBehaviour
{
    [SerializeField] private MusicSO _musicSelected;
    [SerializeField] private WebCamHandler _webcam;

    private int _currentRequest;
    private int _idSession = 10;

    private const string URL = "http://localhost:8080/libraske/game/frame/53";

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

        //while (true)
        {
            WWWForm form = new WWWForm();

            form.AddField("idSong", _musicSelected.GetId());
            form.AddField("idFrame", _currentRequest);

            var image = _webcam.GetImageInBytes();

            if(image != null)
                form.AddBinaryData("frame", image, $"{_idSession}-{_currentRequest}.png", "image/png");

            UnityWebRequest www = UnityWebRequest.Post(URL, form);

            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
                Debug.Log(www.error);
            else
            {
                _currentRequest++;
                Debug.Log("Form upload complete!");
            }
        }
    }
}