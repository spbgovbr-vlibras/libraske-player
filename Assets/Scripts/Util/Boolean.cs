namespace Lavid.Libraske.Util
{
    [System.Serializable]
    public class Boolean
    {
        public static explicit operator Boolean(int value) => new Boolean(value);
        public static explicit operator Boolean(bool value) => new Boolean(value);
        public static explicit operator Boolean(string value) => new Boolean(value);

        public static implicit operator bool(Boolean boolean) => boolean._value;

        public static Boolean True = new Boolean(true);
        public static Boolean False = new Boolean(false);

        public static int FalseInt => 0;
        public static int TrueInt => 1;

        [UnityEngine.SerializeField] private bool _value;

        public Boolean(bool value) => _value = value;
        public Boolean(int value) => _value = value != 0;
        public Boolean(string value) => _value = value.ToUpper() != false.ToString().ToUpper();

        public int ToInt() => _value == false ? 0 : 1;
    }
}