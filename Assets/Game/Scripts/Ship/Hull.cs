//using DefaultNamespace.ScriptableEvents;

using System;
using ScriptableEvents;
using UnityEngine;
using Variables;

namespace Ship
{
    public class Hull : MonoBehaviour
    {
        [SerializeField] private IntVariable _health;
        [SerializeField] private ScriptableEvent<int> _onHealthChangedEvent;
        
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (string.Equals(other.gameObject.tag, "Asteroid"))
            {
                Debug.Log("Hull collided with Asteroid");
                ApplyHealthChange();
            }
        }

        private void ApplyHealthChange()
        {
            _health.ApplyChange(-1); 
            _onHealthChangedEvent.Raise();
        }

        private void OnEnable()
        {
            _onHealthChangedEvent.Register(_health.ApplyChange);
        }

        private void OnDisable()
        {
            _onHealthChangedEvent.Unregister(_health.ApplyChange);
        }
    }
}
