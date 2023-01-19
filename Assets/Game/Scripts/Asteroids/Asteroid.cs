using System.Security.Cryptography;
using DefaultNamespace.GameEvents;
using ScriptableEvents;
using UnityEngine;
using Variables;
using Random = UnityEngine.Random;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Asteroid : MonoBehaviour
    {
        [SerializeField] private IntVariable _asteroidsDestroyed;
        [SerializeField] private ScriptableEvent _onAsteroidDestroyed;
        [SerializeField] private GameEventVector3 _onLargeDestroyed;
        
        
        
        [Header("Config:")] 
        public GameConfig Config;
        
        [Header("References:")]
        [SerializeField] private Transform _shape;

        private Rigidbody2D _rigidbody;
        private Vector3 _direction;
        private Color _color;

        [HideInInspector] public bool IsSplit = false;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            GetComponentInChildren<SpriteRenderer>().color = Config.AsteroidColor;
            
            SetDirection();
            AddForce();
            AddTorque();
            SetSize();
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (string.Equals(other.tag, "Laser") && Config.InvincibleLaser)
            {
                HitByLaser();
            }
            else if (string.Equals(other.tag, "Laser") && !Config.InvincibleLaser)
            {
                HitByLaser();
                Destroy(other);
            }
        }

        private void HitByLaser()
        {
            _asteroidsDestroyed.ApplyChange(+1);

            if (_shape.localScale.x >= Config.SizeThreshold && !IsSplit)
            {
                _onLargeDestroyed.Raise(transform.position);
                Destroy(gameObject);
            }
            else
            {
                _onAsteroidDestroyed.Raise();
                Destroy(gameObject);
            }
        }
        
        private void SetDirection()
        {
            var size = new Vector2(3f, 3f);
            var target = new Vector3
            (
                Random.Range(-size.x, size.x),
                Random.Range(-size.y, size.y)
            );

            _direction = (target - transform.position).normalized;
        }

        private void AddForce()
        {
            var force = Random.Range(Config.MinForce, Config.MaxForce);
            _rigidbody.AddForce( _direction * force, ForceMode2D.Impulse);
        }

        private void AddTorque()
        {
            var torque = Random.Range(Config.MinTorque, Config.MaxTorque);
            var roll = Random.Range(0, 2);

            if (roll == 0)
                torque = -torque;
            
            _rigidbody.AddTorque(torque, ForceMode2D.Impulse);
        }

        private void SetSize()
        {
            var size = Random.Range(Config.MinSize, Config.MaxSize);
            _shape.localScale = new Vector3(size, size, 0f);
        }
    }
}
