using UnityEngine;
using UnityEngine.Events;

public class Selection : MonoBehaviour, ISelectionObserver
{
    [SerializeField] private SelectionController _controller;

    [SerializeField] private UnityEvent _onSelect;
    [SerializeField] private UnityEvent _onUnselect;

    public int ID { get; set; }

    private void Awake() => _controller.AddObserver(this);
    
    public void UpdateSelectionValue(int newValue)
    {
        bool isSelected = ID == newValue;

        if (isSelected)
            _onSelect?.Invoke();
        else
            _onUnselect?.Invoke();
    }
}