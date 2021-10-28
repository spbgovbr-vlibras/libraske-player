using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Lavid.Libraske.UI
{
    [RequireComponent(typeof(RawImage))]
    public class RequestImageFromURL : MonoBehaviour
    {
        [SerializeField] private RawImage _image;
        [SerializeField, Tooltip("Texture to apply case fail to get image from url")] private Texture _applyCaseFail;

        public void SetTexture(Texture texture) => _image.texture = texture;
        public RawImage GetRawImage() => _image;

        public void SetImageFrom(string url)
        {
            if(gameObject.activeInHierarchy)
                StartCoroutine(DownloadImage(url));
        }

        private IEnumerator DownloadImage(string url)
        {
            var request = WebRequestFormater.GetTexture(url);

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log("[URL Image]: " + request.error);

                if (_applyCaseFail != null)
                    _image.texture = _applyCaseFail;
            }
            else
            {
                var img = DownloadHandlerTexture.GetContent(request);

                if (img != null)
                    _image.texture = img;
            }
        }

        private void OnDestroy() => StopAllCoroutines();
    }
}