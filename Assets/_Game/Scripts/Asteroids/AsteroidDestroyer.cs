using System;
using System.Collections.Generic;
using UnityEngine;
using Variables;

namespace Asteroids
{[CreateAssetMenu(fileName = "new Asteroid Destroyer", menuName = "ScriptableObjects/Asteroid Destroyer", order = 0)]
    public class AsteroidSet : ScriptableObject
    {
        private Dictionary<int, Asteroid> _asteroids = new Dictionary<int, Asteroid>();
        [SerializeField] private IntVariable _asteroidsDestroyed;

        private void Awake()
        {
            Clear();
        }

        public void Add()
        {
            
        }

        public void Remove()
        {
            
        }

        public Asteroid Get(int id)
        {
            return null;
        }

        private void Clear()
        {
            _asteroids = new Dictionary<int, Asteroid>();
        }
    }
    
    public class AsteroidDestroyer : MonoBehaviour
    {
        [SerializeField] private AsteroidSet _asteroids;

        public void OnAsteroidHitByLaser(int asteroidId)
        {
            // Get the asteroid
            
            // Check if big or small
            
            // if small enough, we Destroy
            
            // if it's big, we split it up.
        }

        public void RegisterAsteroid(Asteroid asteroid)
        {
            
        }

        private void DestroyAsteroid(Asteroid asteroid)
        {
            //_asteroids.Remove();
        }
    }
}
