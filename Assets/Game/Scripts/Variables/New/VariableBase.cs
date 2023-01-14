using System;
using UnityEngine;

namespace Variables
{
    public abstract class VariableBase<T> : ScriptableObject
    {
        [SerializeField] protected T _value;
        protected T _currentValue;
        
        public T CurrentValue => _currentValue;

        private void OnEnable()
        {
            _currentValue = _value;
        }
    }
    
    public abstract class VariableBase<T, TVariable> : VariableBase<T> where TVariable : VariableBase<T>
    {
        public virtual void Set(T value)
        {
            _currentValue = value;
        }

        public virtual void Set(TVariable variable)
        {
            _currentValue = variable.CurrentValue;
        }
    }
}