using System;

namespace Lavid.Libraske.Util
{
    [System.Serializable]
    public class Boolean
    {
        public static explicit operator Boolean(int value) => new Boolean(value);
        public static explicit operator Boolean(bool value) => new Boolean(value);

        public static Boolean True = new Boolean(true);
        public static Boolean False = new Boolean(false);

        public static int FalseInt => 0;
        public static int TrueInt => 1;

        private bool _value;
        public bool Value { get => _value; set => _value = value; }

        public Boolean(bool value) => _value = value;
        public Boolean(int value) => _value = value != 0;

        public int ToInt() => _value == false ? 0 : 1;
    }
}