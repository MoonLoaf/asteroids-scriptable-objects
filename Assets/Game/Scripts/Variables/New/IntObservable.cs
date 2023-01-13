using System;
using ScriptableEvents;
using UnityEngine;

namespace Variables
{
    [CreateAssetMenu(fileName = "new IntVariable", menuName = "Variables/Observables/Int Observable")]
    public class IntObservable : IntVariable
    {
        [SerializeField] private ScriptableEventInt _onValueChanged;
        
        public override void Set(int value)
        {
            base.Set(value);
            Raise();
        }

        public override void Set(IntVariable variable)
        {
            base.Set(variable);
            Raise();
        }

        public override void ApplyChange(int amount)
        {
            base.ApplyChange(amount);
            Raise();
        }

        public override void ApplyChange(IntVariable variable)
        {
            base.ApplyChange(variable);
            Raise();
        }
        
        private void Raise()
        {
            _onValueChanged.Raise(Value);
        }

        public void Register(Action<int> onValueChanged)
        {
            _onValueChanged.Register(onValueChanged);
        }

        public void Unregister(Action<int> onValueChanged)
        {
            _onValueChanged.Unregister(onValueChanged);
        }
    }
}