using Lavid.Libraske.DataStruct;
using UnityEngine;

public class DotUIController : MonoBehaviour
{
    [SerializeField] private Wrapper<DotUI> _dots;
    private int _currentSelection;

    private void Start()
    {
        for (int i = 0; i < _dots.Length; i++)
            _dots[i].SetId(i);

        UpdateDots();
    }
	
	public void SelectId(int id)
	{
		_currentSelection = id;
		UpdateDots();
	}

    public void Increase()
    {
        _currentSelection++;
        UpdateDots();
    }

    public void Decrease()
    {
        _currentSelection--;
        UpdateDots();
    }

    private void UpdateDots()
    {
        for (int i = 0; i < _dots.Length; i++)
            _dots[i].UpdateSelectionNumber(_currentSelection);
    }
}
