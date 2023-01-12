using DefaultNamespace.ScriptableEvents;
using UnityEngine;

namespace Variables
{
    [CreateAssetMenu(fileName = "new Float Observable", menuName = "ScriptableObjects/Variables/Float Observable")]
    public class FloatObservable : FloatVariable
    {
        [SerializeField] private ScriptableEventFloatReference _onValueChangedEvent;
        
        public override void ApplyChange(float change)
        {
            base.ApplyChange(change);
            // TODO I don't love creating a new instance here
            _onValueChangedEvent.Raise(new FloatReference(this));
        }
    }
}