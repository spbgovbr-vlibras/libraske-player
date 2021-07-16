using Lavid.Libraske.DataStruct;
using UnityEngine;

public class MenuSelectionView : MonoBehaviour, ISelectionObserver
{
    [SerializeField] private SelectionController _selectionController;
    [SerializeField] private Animator _anim;
    [SerializeField] private Wrapper<MusicDisplay> _displays;

    private void Start()
    {
        //int displaysToUse = _displays.Length;

        //while(_selectionController.GetQuantityOfItems() < displaysToUse)
        //{
        //    _displays.At(displaysToUse -1).gameObject.SetActive(false);
        //    displaysToUse--;
        //}
    }

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