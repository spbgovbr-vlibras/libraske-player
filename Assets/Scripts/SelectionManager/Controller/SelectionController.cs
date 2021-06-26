using Lavid.Libraske.DataStruct;
using System;
using UnityEngine;

public abstract class SelectionController : SelectionSubject
{
    [SerializeField] private ClampedValue _currentSelection;
    [SerializeField] private Selection[] _selections;

    public event Action OnSelectionChange;

    private void Start()
    {
        for (int i = 0; i < _selections.Length; i++)
        {
            _selections[i].ID = i;
        }

        UpdateValues();
    }

    public ClampedValue GetClampedValue() => _currentSelection;

    protected abstract void VerifyInputs();
    protected void Increase() => _currentSelection.Add(1);
    protected void Decrease() => _currentSelection.Add(-1);
    protected void Update() => VerifyInputs();

    /// <summary> Update all selections from this menu with the current value </summary>
    public void UpdateValues() => NotifyObservers((int)_currentSelection.GetCurrentValue());
}