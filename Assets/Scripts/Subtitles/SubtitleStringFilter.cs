namespace Lavid.Libraske.Subtitles
{
    internal static class SubtitleStringFilter
    {
        private static char FloatCommaCharacter { get => '.'; }
        private static char TextCommaCharacter { get => ','; }

        private static bool IsComma(char c) => c == FloatCommaCharacter || c == TextCommaCharacter;
        private static bool IsANumber(char c)
        {
            switch (c)
            {
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    return true;
                default:
                    return false;
            }
        }

        internal static string ToNumberString(string str)
        {
            string output = "";

            foreach (char c in str.ToCharArray())
            {
                if (IsANumber(c))
                    output += c;
                else if (IsComma(c))
                    output += FloatCommaCharacter;
            }

            return output;
        }
    }
}