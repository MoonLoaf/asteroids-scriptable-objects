using System;
using ScriptableEvents;
//using DefaultNamespace.ScriptableEvents;
using UnityEngine;
using Variables;

namespace Ship
{
    public class Gun : MonoBehaviour
    {
        [Header("Laser Prefab")]
        [SerializeField] private Laser _laserPrefab;

        [Space, Header("Variables and Events")] 
        
        [SerializeField] private ScriptableEvent _onLaserFiredEvent;
        [SerializeField] private IntVariable _lasersFired;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                Shoot();
        }
        
        private void Shoot()
        {
            var trans = transform;
            Instantiate(_laserPrefab, trans.position, trans.rotation);
            ApplyLasersChanged();
        }

        private void ApplyLasersChanged()
        {
            _lasersFired.ApplyChange(+1);
            _onLaserFiredEvent.Raise();
        }
    }
}
