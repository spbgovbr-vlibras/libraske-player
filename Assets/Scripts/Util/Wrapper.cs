namespace Lavid.Libraske.DataStruct 
{
    [System.Serializable]
    public class Wrapper<T>
    {
        public T[] Items;

        public Wrapper(T[] value) => Items = value;
        public int Length { get => Items.Length; }
    }
}