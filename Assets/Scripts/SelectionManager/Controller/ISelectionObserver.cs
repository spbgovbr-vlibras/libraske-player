public interface ISelectionObserver
{
    void UpdateSelectionValue(int newValue);
}

public interface ISelectable : ISelectionObserver
{
    int ID { get; }
    void OnSelected();
    void OnUnselected();
}