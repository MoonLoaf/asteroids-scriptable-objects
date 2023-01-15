using UnityEngine;
using Variables;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "Ship Config", menuName = "Configs/Ship Config", order = 0)]
    public class ShipConfig : ScriptableObject
    {
        public float ThrottleForce;
        public float RotationForce;
    }
    
}
