using UnityEngine;
using UnityEngine.UI;

public class DotUI : MonoBehaviour
{
	private enum FillMode { HigherOrEquals, Equals }
			
    [SerializeField] private Image _renderer;
    [SerializeField] private Sprite _whenFilled;
    [SerializeField] private Sprite _whenNotFilled;
	[SerializeField] private FillMode _fillMode;
    
    private int _id;
    public void SetId(int value) => _id = value;

    public void UpdateSelectionNumber(int number)
	{
		if(_fillMode == FillMode.HigherOrEquals)
			_renderer.sprite = number >= _id ? _whenFilled : _whenNotFilled;
		else if(_fillMode == FillMode.Equals)
			_renderer.sprite = number == _id ? _whenFilled : _whenNotFilled;
	}
}