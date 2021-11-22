using UnityEngine;

public class MenuSelectionView : MonoBehaviour, ISelectionObserver
{
    [SerializeField] private SelectionController _selectionController;
    [SerializeField] private Animator _anim;

    private struct Animations
    {
        public const string SelectLast = "selectionLast";
        public const string SelectionIndex = "selectionIndex";
    }

    public void UpdateSelectionValue(int newValue)
    {
        _anim.SetInteger(Animations.SelectionIndex, newValue);
        _anim.SetBool(Animations.SelectLast, _selectionController.IsSelectingLastItem());
    }
}