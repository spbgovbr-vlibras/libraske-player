namespace Lavid.Libraske.DataStruct 
{
    [System.Serializable]
    public class Wrapper<T>
    {
        [UnityEngine.SerializeField] private T[] _items;

        //public T[] Items { get => _items; }
        /// <returns> Returns element in a required index position </returns>
        public T At(int index) => _items[index];
        public void SetValue(int index, T value) => _items[index] = value;
        public Wrapper() => _items = new T[0];
        public Wrapper(int size) => _items = new T[size];
        public Wrapper(T[] value) => _items = value;
        public Wrapper(System.Collections.Generic.List<T> value) => _items = value.ToArray();
        public int Length { get => _items.Length; }
    }
}