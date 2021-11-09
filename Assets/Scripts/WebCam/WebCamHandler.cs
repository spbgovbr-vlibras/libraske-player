using UnityEngine;
using UnityEngine.UI;

public class WebCamHandler : MonoBehaviour
{
    [SerializeField, Tooltip("The renderer to handle the webcam's texture.")] private Image _renderer;
    private WebCamTexture _webcam;

    private void Awake() => EnableWebcam();
    private void OnDestroy() => DisableWebcam();

    public void EnableWebcam()
    {
        _webcam = new WebCamTexture();
        _webcam.Play();
        _renderer.material.mainTexture = _webcam;
        _renderer.enabled = true;
    }

    public void DisableWebcam()
    {
        if (_webcam != null)
            _webcam.Stop();
    }

    public byte[] GetImageInBytes()
    {
		Texture2D photo = new Texture2D(_webcam.width, _webcam.height);
        photo.SetPixels(_webcam.GetPixels());
        photo.Apply();
		return photo.EncodeToPNG();
    }
}