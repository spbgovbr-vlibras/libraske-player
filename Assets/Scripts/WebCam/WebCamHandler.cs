using UnityEngine;
using UnityEngine.UI;

public class WebCamHandler : MonoBehaviour
{
    [SerializeField, Tooltip("The renderer to handle the webcam's texture.")] private Image _renderer;
    private WebCamTexture _webcam;

    private int _webcamWidth;
    private int _webcamHeight;
    private Color[] _pixels;
    private Texture2D _currentTexture;

    private void Awake()
    {
        _webcam = new WebCamTexture();
        _webcam.Play();
        _renderer.material.mainTexture = _webcam;
        _renderer.enabled = true;

        _webcamWidth = _webcam.width;
        _webcamHeight = _webcam.height;

        _currentTexture = new Texture2D(_webcamWidth, _webcamHeight);
    }

    private void OnDestroy()
    {
        if (_webcam != null)
            _webcam.Stop();
    }

    private void UpdateCurrentTexture()
    {
        _pixels = _webcam.GetPixels();
        _currentTexture.SetPixels(_pixels);
        _currentTexture.Apply();
    }

    public byte[] GetImageInBytes()
    {
		Texture2D photo = new Texture2D(_webcam.width, _webcam.height);
        photo.SetPixels(_webcam.GetPixels());
        photo.Apply();
		return photo.EncodeToPNG();
		
        /*UpdateCurrentTexture();
		

        byte[] pngPhoto = null;

        try
        {
            pngPhoto = _currentTexture.EncodeToPNG();
        }
        catch 
        {
            Debug.LogWarning("Erro ao codificar imagem");
        }
        
        return pngPhoto;*/
    }
}