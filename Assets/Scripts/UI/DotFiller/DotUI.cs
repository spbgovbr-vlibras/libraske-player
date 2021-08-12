using UnityEngine;
using UnityEngine.UI;

public class DotUI : MonoBehaviour
{
    [SerializeField] private Image _renderer;
    [SerializeField] private Sprite _whenFilled;
    [SerializeField] private Sprite _whenNotFilled;
    
    private int _id;
    public void SetId(int value) => _id = value;

    public void UpdateSelectionNumber(int number) => _renderer.sprite = number >= _id ? _whenFilled : _whenNotFilled;
}