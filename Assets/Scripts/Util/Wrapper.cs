using System;
using System.Collections.Generic;

namespace Lavid.Libraske.DataStruct 
{
    [System.Serializable]
    public class Wrapper<T>
    {
        [UnityEngine.SerializeField] private List<T> _items;

        #region Constructors
        public Wrapper() => _items = new List<T>();
        public Wrapper(int size) => _items = new List<T>(size);
        public Wrapper(T[] value)
        {
            List<T> _ = new List<T>();

            foreach (T obj in value)
                _.Add(obj);

            _items = _;
        }
        public Wrapper(List<T> value) => _items = value;
        #endregion


        public void Add(T obj) => _items.Add(obj);
        public void Remove(T obj) => _items.Remove(obj);
        public bool Contains(T obj) => _items.Contains(obj);
        public int Length { get => _items.Count; }


        /// <returns> Returns element in a required index position </returns>
        public T this[int index] 
        {
            get => _items[index];
            set => _items[index] = value;
        }

        [Obsolete("At(index) is deprecated, please use object[index] instead.")]
        public T At(int index) => _items[index];
        public void SetValue(int index, T value) => _items[index] = value;
    }
}