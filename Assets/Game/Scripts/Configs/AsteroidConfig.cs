using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Variables;

[CreateAssetMenu(fileName = "Asteroid Config", menuName = "Configs/Asteroid Config", order = 0)]
public class AsteroidConfig : ScriptableObject
{
    [Header("Ship Config")]
    [Header("Damage")]
    public float Damage;
    
    [Space] [Header("Force")]
    public float MinForce;
    public float MaxForce;
    
    [Header("Size")]
    public float MinSize;
    public float MaxSize;
    
    [Header("Torque")]
    public float MinTorque;
    public float MaxTorque;
}
