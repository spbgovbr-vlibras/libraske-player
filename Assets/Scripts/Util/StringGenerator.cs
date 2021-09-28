using UnityEngine;

namespace Lavid.Libraske.Util
{
    public static class StringGenerator
    {
        private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        public static string GenerateString(int quant)
        {
            char[] _ = new char[quant];

            for (int i = 0; i < _.Length; i++)
            {
                _[i] = Chars[Random.Range(0, _.Length)];
            }

            return new string(_);
        }
    }
}