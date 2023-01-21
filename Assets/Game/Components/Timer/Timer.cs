using System;
using System.Collections;
using ScriptableEvents;
using UnityEngine;
using Variables;

namespace Components
{
    public class Timer : MonoBehaviour
    {
        [Header("Config")]
        [SerializeField] private GameConfig _config;

        
        
        [Header("Variables and Events")]
        [SerializeField] private ScriptableEvent _onTimePassed;
        [SerializeField] private IntVariable _timeLeft;
        [SerializeField] private ScriptableEvent _onGameOver;
        
        [Header("UI")]
        [SerializeField] private GameObject _endScreen;

        private void OnEnable()
        {
            _timeLeft.Set(_config.TimeLeft);
        }

        private void Start()
        {
            StartCoroutine(RepeatMethod());
        }

        private bool _stopCoroutine = false;
        private IEnumerator RepeatMethod()
        {
            while (!_stopCoroutine)
            {
                if (_timeLeft.CurrentValue == 0) 
                {
                    _stopCoroutine = true;
                    _onGameOver.Raise();
                    yield break;
                }
                RemoveSecond();
                yield return new WaitForSeconds(1);
            }
        }

        private void RemoveSecond()
        {
            _timeLeft.ApplyChange(-1);
            _onTimePassed.Raise();
        }
    }
}
