using System;
using System.Collections;
using ScriptableEvents;
//using DefaultNamespace.ScriptableEvents;
using UnityEngine;
using Variables;

namespace Components.Timer
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private ScriptableEvent _onTimePassed;
        [SerializeField] private IntVariable _timeLeft;

        private void Start()
        {
            StartCoroutine(RepeatMethod());
        }

        private IEnumerator RepeatMethod()
        {
            while (true)
            {
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
