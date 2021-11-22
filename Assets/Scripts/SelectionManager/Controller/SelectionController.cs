using Lavid.Libraske.DataStruct;
using UnityEngine;

public abstract class SelectionController : SelectionSubject
{
    [SerializeField] private IntClampedValue _currentSelection;
    [SerializeField] private Wrapper<GameObject> _selectionObservers;

    private Wrapper<object> _items;
    private Wrapper<ISelectionObserver> _observers;

    private void Awake()
    {
        _observers = new Wrapper<ISelectionObserver>(_selectionObservers.Length);

        if (_items == null)
            _items = new Wrapper<object>();

        for (int i = 0; i < _selectionObservers.Length; i++)
        {
            _observers.SetValue(i, _selectionObservers[i].GetComponent<ISelectionObserver>());
            AddObserver(_observers[i]);
        }
            
        NotifyObservers();
    }

    protected void Update() => VerifyInputs();
    protected abstract void VerifyInputs();

    public bool IsSelectingLastItem() => _currentSelection.GetCurrentValue() >= _currentSelection.GetMaxValue();

    public int GetQuantityOfItems() => _items.Length;
    public object GetItem(int index) => _items[index];

    protected void Increase() => _currentSelection.Add(1);
    protected void Decrease() => _currentSelection.Add(-1);
    
    public void NotifyObservers() => NotifyObservers(_currentSelection.GetCurrentValue());
}