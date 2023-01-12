using UnityEngine;

namespace Variables
{
    [CreateAssetMenu(fileName = "new FloatVariable", menuName = "ScriptableObjects/Variables/FloatVariable")]
    public class FloatVariable : ScriptableObject
    {
        [SerializeField] private float _value;

        public float Value => _currentValue;

        private float _currentValue;
        
        public virtual void ApplyChange(float change)
        {
            _currentValue += change;
        }

        public virtual void SetValue(float newValue)
        {
            _currentValue = newValue;
        }

        private void OnEnable()
        {
            _currentValue = _value;
        }
    }
}
