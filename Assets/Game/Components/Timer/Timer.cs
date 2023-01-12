using System;
using System.Collections;
using DefaultNamespace.ScriptableEvents;
using UnityEngine;
using Variables;

namespace Components.Timer
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private ScriptableEventFloatReference _onTimePassedEvent;
        [SerializeField] private FloatReference _timePasssedRef;
        [SerializeField] private FloatObservable _timePassedObservable;

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
            _timePasssedRef.ApplyChange(-1f);
            _onTimePassedEvent.Raise(_timePasssedRef);
            _timePassedObservable.ApplyChange(-1);
        }
    }
}
