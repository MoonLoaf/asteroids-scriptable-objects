using System;
using DefaultNamespace.ScriptableEvents;
using UnityEngine;
using Variables;

namespace Ship
{
    public class Gun : MonoBehaviour
    {
        [Header("Laser Prefab")]
        [SerializeField] private Laser _laserPrefab;

        [Space, Header("Variables and Events")] 
        
        [SerializeField] private ScriptableEventIntReference _onLaserFiredEvent;
        [SerializeField] private IntReference _lasersFiredRef;
        [SerializeField] private IntObservable _lasersFiredObservable;

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
            _lasersFiredRef.ApplyChange(+1);
            _onLaserFiredEvent.Raise(_lasersFiredRef);
            _lasersFiredObservable.ApplyChange(+1);
        }
    }
}
