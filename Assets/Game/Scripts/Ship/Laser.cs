using System;
using Asteroids;
using RuntimeSets;
using UnityEngine;

namespace Ship
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Laser : MonoBehaviour
    {
        [SerializeField] private GameConfig _config;
        
        [Header("Project References:")] [SerializeField]
        private LaserRuntimeSet _lasers;

        [Header("Values:")]
        [SerializeField] private float _speed;

        private Rigidbody2D _rigidbody;

        private void Start()
        {
            _speed = _config.LaserSpeed;
            GetComponentInChildren<SpriteRenderer>().color = _config.LaserColor;
            _rigidbody = GetComponent<Rigidbody2D>();
            
            _lasers.Add(gameObject);
        }

        private void OnDestroy()
        {
            _lasers.Remove(gameObject);
        }

        private void FixedUpdate()
        {
            var trans = transform;
            _rigidbody.MovePosition(trans.position + trans.up * _speed);
        }
    }
}
