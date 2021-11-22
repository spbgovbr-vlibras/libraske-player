using UnityEngine;

public class ParticleVerticalMovement : MonoBehaviour
{
    [SerializeField] private RectTransform _particle;

    [Header("Parameters"), Space(3)]
    [SerializeField] private float _speed;
    [SerializeField] private float _minYPosition;
    [SerializeField] private float _maxYPosition;

    private void LateUpdate()
    {
        float delta = _speed * Time.deltaTime;

        if (_particle.anchoredPosition.y + delta >= _maxYPosition)
            _particle.anchoredPosition = new Vector2(_particle.anchoredPosition.x, _minYPosition);
        else
            _particle.anchoredPosition += new Vector2(0, delta);
    }
}
