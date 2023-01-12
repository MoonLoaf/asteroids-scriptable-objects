using UnityEngine;
using Variables;

namespace DefaultNamespace.ScriptableEvents
{
    [CreateAssetMenu(fileName = "new ScriptableEventFloatReference", menuName = "ScriptableObjects/ScriptableEvent-FloatReference", order = 0)]
    public class ScriptableEventFloatReference : ScriptableEvent<FloatReference>
    {
        public void Raise(float newValue)
        {
            Raise(new FloatReference(newValue));
        }
    }
}