using UnityEngine;

[CreateAssetMenu(fileName = "Game Config", menuName = "Configs/Game Config", order = 0)]
public class GameConfig : ScriptableObject
{
    //Time
    public int TimeLeft;
    
    //Asteroid Config
    public int Damage;

    public Color AsteroidColor;
    
    public float MinForce;
    public float MaxForce;
    
    public float MinSize;
    public float MaxSize;
    
    public float SizeThreshold;
    
    //Ship Config
    public Color ShipColor;
    public int Health;
    
    public float MinTorque;
    public float MaxTorque;

    public float ThrottleForce;
    public float RotationForce;
    
    //Laser Config
    public Color LaserColor;
    public float LaserSpeed;
    public bool InvincibleLaser;
    
    //Asteroid SpawnDirection
    public enum SpawnLocation{
        Any,
        Top,
        Bottom,
        Right,
        Left
    }

    public SpawnLocation SpawnLocationActive;

}
