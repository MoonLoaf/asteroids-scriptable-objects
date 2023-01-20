using System;
using System.Runtime.CompilerServices;
using ScriptableEvents;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Asteroids
{
    public class AsteroidSpawner : MonoBehaviour
    {

        [SerializeField] private GameConfig _config;
        [SerializeField] private Asteroid _asteroidPrefab;
        
        [SerializeField] private float _minSpawnTime;
        [SerializeField] private float _maxSpawnTime;
        [SerializeField] private int _minAmount;
        [SerializeField] private int _maxAmount;
        
        private float _timer;
        private float _nextSpawnTime;
        private Camera _camera;
        private GameConfig.SpawnLocation _selectedSpawn;

        private void Start()
        {
            _selectedSpawn = _config.SpawnLocationActive;
            _camera = Camera.main;
            Spawn();
            UpdateNextSpawnTime();
            
        }

        private void Update()
        {
            UpdateTimer();

            if (!ShouldSpawn())
                return;

            Spawn();
            UpdateNextSpawnTime();
            _timer = 0f;
        }

        private void UpdateNextSpawnTime()
        {
            _nextSpawnTime = Random.Range(_minSpawnTime, _maxSpawnTime);
        }

        private void UpdateTimer()
        {
            _timer += Time.deltaTime;
        }

        private bool ShouldSpawn()
        {
            return _timer >= _nextSpawnTime;
        }

        private void Spawn()
        {
            var amount = Random.Range(_minAmount, _maxAmount + 1);
            
            for (var i = 0; i < amount; i++)
            {
                
                var position = GetStartPosition(_selectedSpawn);
                Instantiate(_asteroidPrefab, position, Quaternion.identity);
            }
        }
        
        private Vector3 GetStartPosition(GameConfig.SpawnLocation selectedSpawn)
        {
            var pos = new Vector3 { z = Mathf.Abs(_camera.transform.position.z) };
            
            const float padding = 5f;
            switch (selectedSpawn)
            {
                case GameConfig.SpawnLocation.Any:
                    int random = Random.Range(0, 4);
                    switch (random)
                    {
                        case 0:
                            SpawnTop();
                            break;
                        case 1:
                            SpawnBottom();
                            break;
                        case 2:
                            SpawnLeft();
                            break;
                        case 3:
                            SpawnRight();
                            break;
                    }
                    break;
                case GameConfig.SpawnLocation.Top:
                    SpawnTop();
                    break;
                case GameConfig.SpawnLocation.Bottom:
                    SpawnBottom();
                    break;
                case GameConfig.SpawnLocation.Left:
                    SpawnLeft();
                    break;
                case GameConfig.SpawnLocation.Right:
                    SpawnRight();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(_selectedSpawn), _selectedSpawn, null);
            }
            void SpawnTop()
            {
                pos.x = Random.Range(0f, Screen.width);
                pos.y = Screen.height + padding;
            }
            void SpawnBottom()
            {
                pos.x = Random.Range(0f, Screen.width);
                pos.y = 0f - padding;
            }
            void SpawnLeft()
            {
                pos.x = 0f - padding;
                pos.y = Random.Range(0f, Screen.height);
            }
            void SpawnRight()
            {
                pos.x = Screen.width - padding;
                pos.y = Random.Range(0f, Screen.height);
            }
            return _camera.ScreenToWorldPoint(pos);
        }
        public void OnLargeDestroyed(Vector3 onDestroyedPos)
        {
            for (int i = 0; i < 2; i++)
            {
                var splitAsteroid = Instantiate(_asteroidPrefab, onDestroyedPos, Quaternion.identity);

                var size = Random.Range(splitAsteroid.Config.MinSize, splitAsteroid.Config.MaxSize - 0.6f);
                splitAsteroid.transform.localScale = new Vector3(size, size, 0f);
                
                splitAsteroid.GetComponent<Asteroid>().IsSplit = true;
            }
        }
    }
}
