namespace Lavid.Libraske.DataStruct
{
    internal class DoubleLinkedNode<T>
    {
        internal DoubleLinkedNode<T> _previous;
        internal T _value;
        internal DoubleLinkedNode<T> _next;

        public bool HasNext() => _next != null;
        public bool HasPrevious() => _previous != null;

        public T GetValue() => _value;
        public DoubleLinkedNode<T> GetNext() => _next;
        public DoubleLinkedNode<T> GetPrevious() => _previous;
    }
}