using UnityEngine;

namespace Lavid.Libraske.DataStruct
{
    [System.Serializable]
    public class IntClampedValue
    {
        [SerializeField] private int _currentValue;
        [SerializeField] private int _min;
        [SerializeField] private int _max;

        public IntClampedValue(int min, int currentValue, int max) => (_min, _currentValue, _max) = (min, currentValue, max);

        public float GetMinValue() => _min;
        public int GetCurrentValue() => _currentValue;
        public float GetMaxValue() => _max;

        public void Add(int value)
        {
            _currentValue += value;

            if (_currentValue > _max)
                _currentValue = _max;

            if (_currentValue < _min)
                _currentValue = _min;
        }
    }
}