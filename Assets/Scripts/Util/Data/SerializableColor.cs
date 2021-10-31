using System;
using UnityEngine;

namespace Lavid.Libraske.Util
{
    [Serializable]
    public class SerializableColor
    {
        [SerializeField] private Color _color;

        public SerializableColor(Vector4 rgba) => _color = rgba;

        public SerializableColor(string hexaCode) 
        {
            var _ = new Color();
            ColorUtility.TryParseHtmlString(hexaCode, out _);
            _color = _;
        }

        public Vector4 GetInVector4() => _color;
        public string GetInHexaCode() => ColorUtility.ToHtmlStringRGBA(_color);

        public static implicit operator Color(SerializableColor sc) => new Color(sc._color.r, sc._color.g, sc._color.b, sc._color.a);
        public static explicit operator SerializableColor(Color color) => new SerializableColor(color);
    }
}