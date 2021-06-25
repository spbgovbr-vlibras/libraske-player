using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public partial class SubtitleBar : MonoBehaviour
{
    [SerializeField] private RectTransform _image;

    private float _height;

    private void Awake()
    {
        _image = GetComponent<RectTransform>();
        _height = _image.sizeDelta.y;
        Disable();
    }

    public void Disable() => _image.sizeDelta = new Vector2(0, _height);

    /// <summary> Set size based on subtitle's line size. </summary>
    /// <param name="subtitleLine"></param>
    public void SetSize(string subtitleLine)
    {
        char[] charArray = subtitleLine.ToCharArray();

        int width = 0;

        for (int i = 0; i < charArray.Length; i++)
        {
            width += GetSizeOfBar(charArray[i]);

            if (charArray[i] == 'L')
                Debug.Log(GetSizeOfBar(charArray[i]));
        }

        Debug.Log(width);

        _image.sizeDelta = new Vector2(width,_height);
    }
}
