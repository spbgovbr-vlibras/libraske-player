using System;
using System.Collections.Generic;

namespace Lavid.Libraske.DataStruct 
{
    [System.Serializable]
    public class Wrapper<T>
    {
        [UnityEngine.SerializeField] private List<T> Items;

        #region Constructors
        public Wrapper() => Items = new List<T>();
        public Wrapper(int size) => Items = new List<T>(size);
        public Wrapper(T[] value)
        {
            List<T> _ = new List<T>();

            foreach (T obj in value)
                _.Add(obj);

            Items = _;
        }
        public Wrapper(List<T> value) => Items = value;
        #endregion


        public void Add(T obj) => Items.Add(obj);
        public void Remove(T obj) => Items.Remove(obj);
        public bool Contains(T obj) => Items.Contains(obj);
        public int Length { get => Items.Count; }


        /// <returns> Returns element in a required index position </returns>
        public T this[int index] 
        {
            get => Items[index];
            set => Items[index] = value;
        }

        [Obsolete("At(index) is deprecated, please use object[index] instead.")]
        public T At(int index) => Items[index];
        public void SetValue(int index, T value) => Items[index] = value;
    }
}