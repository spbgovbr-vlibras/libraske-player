using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public partial class SubtitleBar : MonoBehaviour
{
    private const int ValuePerUpperCaseCharacter = 86;
    private const int ValuePerLowerCaseCharacter = 66;
    private const int ValuePerSpecialCharacter = 40;

    private const int ValuePerTinyLetterLow = 36; // i, I, l, t, T, 1, j
    private const int ValuePerLetterRLower = 46;
    private const int ValuePerLetterMLower = 100;
    private const int ValuePerLetterWLower = 86;
    private const int ValuePerLetterWUpper = 110;

    public int GetSizeOfBar(char ch)
    {
        switch (ch)
        {
            case 'm':
                return ValuePerLetterMLower;

            case 'r':
                return ValuePerLetterRLower;

            case 'I':
            case 'i':
            case 't':
            case 'T':
            case 'l':
            case 'f':
            case '1':
            case 'j':
                return ValuePerTinyLetterLow;

            case 'w':
                return ValuePerLetterWLower;

            case 'W':
                return ValuePerLetterWUpper;

            case 'L':
                return 0;

        }

         if (ch >= 'a' && ch <= 'z')
            return ValuePerLowerCaseCharacter;

        else if (ch >= 'A' && ch <= 'Z')
            return ValuePerUpperCaseCharacter;

        else if (ch >= '0' && ch <= '9')
            return ValuePerLowerCaseCharacter;

        else return ValuePerSpecialCharacter;
    }
}