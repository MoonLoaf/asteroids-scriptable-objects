using UnityEditor.VersionControl;
using UnityEngine;
using Variables;

namespace Ship
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Engine : MonoBehaviour
    {
        [SerializeField] private FloatVariable _throttlePower;
        [SerializeField] private FloatVariable _rotationPower;
        
        private Rigidbody2D _rigidbody;
        
        private void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Throttle();
            }
        
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                SteerLeft();
            } 
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                SteerRight();
            }
        }

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Throttle()
        {
            _rigidbody.AddForce(transform.up * _throttlePower.CurrentValue, ForceMode2D.Force);
        }

        private void SteerLeft()
        {
            _rigidbody.AddTorque(_rotationPower.CurrentValue, ForceMode2D.Force);
        }

        private void SteerRight()
        {
            _rigidbody.AddTorque(-_rotationPower.CurrentValue, ForceMode2D.Force);
        }
    }
}
