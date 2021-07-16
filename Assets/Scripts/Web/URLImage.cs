using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class URLImage : MonoBehaviour
{
    [SerializeField] private RawImage _image;
    [SerializeField] private string _url;

    private void Awake() => StartCoroutine(DownloadImage());

    private IEnumerator DownloadImage()
    {
        var request = WebRequest.GetTexture(_url);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            Debug.Log(request.error);
        else
        {
            var img = DownloadHandlerTexture.GetContent(request);

            if(img != null)
                _image.texture = img;
        }
            
    }
}
