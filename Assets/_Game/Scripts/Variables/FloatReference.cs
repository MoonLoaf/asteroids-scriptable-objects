using System;
using DefaultNamespace.ScriptableEvents;
using UnityEngine;

namespace Variables
{
    [Serializable]
    public class FloatReference
    {
        // TODO Can we make this look nicer with a custom property drawer?
        [SerializeField] private FloatVariable _floatVariable;
        [SerializeField] private float _simpleValue;
        [SerializeField] private bool _useSimple;

        public FloatReference(FloatVariable variable)
        {
            _floatVariable = variable;
            _useSimple = false;
        }

        public FloatReference(float value)
        {
            _simpleValue = value;
            _useSimple = true;
        }

        public float GetValue()
        {
            return _useSimple ? _simpleValue : _floatVariable.Value;
        }
        public void ApplyChange(float change)
        {
            if (_useSimple)
            {
                _simpleValue += change;
            }
            else
            {
                _floatVariable.ApplyChange(change);
            }
        }
    }
}