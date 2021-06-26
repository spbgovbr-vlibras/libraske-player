using UnityEngine;

namespace Lavid.Libraske.DataStruct
{
    [System.Serializable]
    public class ClampedValue
    {
        [SerializeField] private float _currentValue;
        [SerializeField] private float _min;
        [SerializeField] private float _max;

        public ClampedValue(float min, float currentValue, float max) => (_min, _currentValue, _max) = (min, currentValue, max);

        public float GetMinValue() => _min;
        public float GetCurrentValue() => _currentValue;
        public float GetMaxValue() => _max;

        public void Add(float value)
        {
            _currentValue += value;

            if (_currentValue > _max)
                _currentValue = _max;

            if (_currentValue < _min)
                _currentValue = _min;
        }
    }
}