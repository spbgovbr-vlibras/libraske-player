using UnityEngine;

public class MusicSelectionView : MonoBehaviour, ISelectionObserver
{
    [SerializeField] private SelectionController _controller;
    [SerializeField] private Animator _anim;

    private int _maxValue;
    private const string SelectLastAnimationName = "selectLastMusic";
    private const string SelectionAnimationName = "selection";

    private void Awake()
    {
        _controller.AddObserver(this);
        _maxValue = (int) _controller.GetClampedValue().GetMaxValue();
    }

    public void UpdateSelectionValue(int newValue)
    {
        _anim.SetBool(SelectLastAnimationName, newValue >= _maxValue);
        _anim.SetInteger(SelectionAnimationName, newValue);
    }
}