using UnityEngine;

namespace Variables
{
    [CreateAssetMenu(fileName = "new IntVariable", menuName = "Variables/Int Variable")]
    public class IntVariable :  VariableBase<int, IntVariable>
    {
        public virtual void ApplyChange(int amount)
        {
            _value += amount;
        }

        public virtual void ApplyChange(IntVariable variable)
        {
            _value += variable.Value;
        }
    }
}