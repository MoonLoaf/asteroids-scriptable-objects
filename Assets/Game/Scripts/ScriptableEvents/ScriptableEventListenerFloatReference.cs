using System;
using UnityEngine;
using UnityEngine.Events;
using Variables;

namespace DefaultNamespace.ScriptableEvents
{
    public class ScriptableEventListenerFloatReference : ScriptableEventListener<FloatReference, ScriptableEventFloatReference, UnityEvent<FloatReference>>
    {
       
    }

    [Serializable]
    public class UnityEventFloat : UnityEvent<int>
    {
        
    }
    
    [Serializable]
    public class UnityEventGuidFloat : UnityEvent<Guid>
    {
        
    }
}