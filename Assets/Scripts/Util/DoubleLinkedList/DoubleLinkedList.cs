namespace Lavid.Libraske.DataStruct
{
    public class DoubleLinkedList<T>
    {
        private DoubleLinkedNode<T> _current;

        public void AddItem(T item)
        {
            DoubleLinkedNode<T> temp = new DoubleLinkedNode<T>();

            _current._next = temp;
            temp._previous = _current;

            temp._value = item;

            _current = temp;
        }

        public bool HasNext() => _current.HasNext();
        public bool HasPrevious() => _current.HasPrevious();

        public T GetFirst()
        {
            DoubleLinkedNode<T> first = _current;

            while (first.HasPrevious())
                first = first.GetPrevious();

            return first.GetValue();
        }
        public T GetLast()
        {
            DoubleLinkedNode<T> last = _current;

            while (last.HasNext())
                last = last.GetNext();

            return last.GetValue();
        }
        public T GetCurrent() => _current.GetValue();
        public T GetNext()
        {
            _current = _current.GetNext();
            return _current.GetValue();
        }
        public T GetPrevious()
        {
            _current = _current.GetPrevious();
            return _current.GetValue();
        }
    }
}
