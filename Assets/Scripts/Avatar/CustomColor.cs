using System;
using UnityEngine;

namespace Lavid.Libraske.Color
{
    [Serializable]
    public class CustomColor
    {
        private Vector4 _rgba;

        public CustomColor(Vector4 rgba) => _rgba = rgba;

        public CustomColor(string hexaCode) 
        {
            var _ = new UnityEngine.Color();
            ColorUtility.TryParseHtmlString(hexaCode, out _);
            _rgba = _;
        }

        public Vector4 GetInVector4() => _rgba;
        public string GetInHexaCode() => ColorUtility.ToHtmlStringRGBA(_rgba);

        public static implicit operator UnityEngine.Color(CustomColor sc) => new CustomColor(sc.GetInVector4());
        public static explicit operator CustomColor(UnityEngine.Color color) => new CustomColor(color);
    }
}