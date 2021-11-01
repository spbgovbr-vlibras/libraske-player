using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Lavid.Libraske.UI
{
    [RequireComponent(typeof(RawImage))]
    public class RequestImageFromURL : WebRequest
    {
        [SerializeField] private RawImage _image;
        [SerializeField, Tooltip("Texture to apply case fail to get image from url")] private Texture _applyCaseFail;

        public void SetTexture(Texture texture) => _image.texture = texture;
        public RawImage GetRawImage() => _image;

        private string _url;

        public void SetImageFrom(string url)
        {
            _url = url;

            if(gameObject.activeInHierarchy)
                StartCoroutine(SendRequest());
        }

        public override string GetLogName() => "RequestImageFromURL";

        protected override void OnRequestSuccess(UnityWebRequest request)
        {
            _requestWasSuccess = true;

            var img = DownloadHandlerTexture.GetContent(request);

            if (img != null)
                _image.texture = img;

            PrintSuccessText(request);
            InvokeOnSuccessEvent();
        }

        protected override void OnRequestError(UnityWebRequest request)
        {
            PrintFailText(request);

            if (_applyCaseFail != null)
                _image.texture = _applyCaseFail;

            InvokeOnErrorEvent();
        }

        protected override IEnumerator SendRequest()
        {
            var request = WebRequestFormater.GetTexture(_url);
            yield return request.SendWebRequest();
            VerifyRequest(request);

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
    }
}