//using DefaultNamespace.ScriptableEvents;

using System;
using ScriptableEvents;
using UnityEngine;
using Variables;

namespace Ship
{
    public class Hull : MonoBehaviour
    {
        [SerializeField] private GameConfig _config;
        [SerializeField] private IntVariable _health;
        [SerializeField] private ScriptableEvent _onHealthChangedEvent;
        [SerializeField] private ScriptableEvent _onGameOver;

        private void OnEnable()
        {
            _health.Set(_config.Health);
        }

        private void Start()
        {
            GetComponentInChildren<SpriteRenderer>().color = _config.ShipColor;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (string.Equals(other.gameObject.tag, "Asteroid"))
            {
                ApplyHealthChange(-_config.Damage);
            }
        }

        private void ApplyHealthChange(int change)
        {
            Debug.Log("Hull collided with Asteroid");
            _health.ApplyChange(change); 
            _onHealthChangedEvent.Raise();

            if (_health.CurrentValue == 0)
            {
                _onGameOver.Raise();
            }
        }

        public void DestroyShip()
        {
            Destroy(gameObject);
        }
            
    }
}
