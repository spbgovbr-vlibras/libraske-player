using UnityEngine;
using UnityEngine.UI;

public class WebCamHandler : MonoBehaviour
{
    [SerializeField, Tooltip("The renderer to handle the webcam's texture.")] private Image _renderer;
    [SerializeField, Tooltip("If you want the webcam to be rendered. Exports works anyway.")] private bool _showWebCam;

    private bool _showWebCamLastValue;
    private WebCamTexture _webcam;

    private void Awake()
    {
        _webcam = new WebCamTexture();
        _renderer.material.mainTexture = _webcam;

        _webcam.Play();

        _showWebCamLastValue = !_showWebCam;
        _renderer.enabled = _showWebCam;
    }

    private void LateUpdate()
    {
        if(_showWebCamLastValue != _showWebCam)
        {
            _showWebCamLastValue = _showWebCam;
            _renderer.enabled = _showWebCam;
        }
    }

    public byte[] GetImageInBytes()
    {
        Texture2D photo = new Texture2D(_webcam.width, _webcam.height);
        photo.SetPixels(_webcam.GetPixels());
        photo.Apply();

        return photo.EncodeToPNG();
    }
}