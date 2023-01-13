using System;
using ScriptableEvents;
using TMPro;
using UnityEngine;
using Variables;

namespace UI
{
    public class UI : MonoBehaviour
    {
        [Header("Health:")]
        [SerializeField] private IntVariable _healthVar;
        [SerializeField] private TextMeshProUGUI _healthText;
        [SerializeField] private ScriptableEvent<int> _onHealthChangedEvent;
        
        [Header("Score:")]
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private IntVariable _asteroidsDestroyed;
        [SerializeField] private ScriptableEvent<int> _onAsteroidDestroyed;
        
        [Header("Timer:")]
        [SerializeField] private TextMeshProUGUI _timerText;
        [SerializeField] private IntVariable _timeLeft;
        [SerializeField] private ScriptableEvent<int> _onTimePassed;
        
        [Header("Laser:")]
        [SerializeField] private TextMeshProUGUI _laserText;
        [SerializeField] private IntVariable _lasersFired;
        [SerializeField] private ScriptableEvent<int> _onLaserFired;
        
        private void Start()
        {
            SetHealthText($"Health: {_healthVar.Value}");
            SetScoreText($"Asteroids Destroyed: {_asteroidsDestroyed.Value}");
            SetTimerText($"Time Left: {_timeLeft.Value}");
            SetLaserText($"Lasers Fired: {_lasersFired.Value}");
            
        }

        // ------------HEALTH----------------
        
        private void SetHealthText(string text)
        {
            _healthText.text = text;
        }
        public void OnHealthChanged(IntVariable newValue)
        {
            SetHealthText($"Health: {newValue.Value}");
        }

        // ------------SCORE----------------
        
        private void SetScoreText(string text)
        {
            _scoreText.text = text;
        }
        public void OnAsteroidDestroyed(IntReference newValue)
        {
            SetScoreText($"Asteroids Destroyed: {newValue.GetValue()}");
        }
        
        // ------------TIMER----------------
        
        private void SetTimerText(string text)
        {
            _timerText.text = text;
        }
        public void OnTimePassed(IntReference newValue)
        {
            SetTimerText($"Time Left: {newValue.GetValue()}");
        }
        
        // ------------LASERS----------------
        
        private void SetLaserText(string text)
        {
            _laserText.text = text;
        }
        public void OnLaserFired(IntReference newValue)
        {
            SetLaserText($"Lasers Fired: {newValue.GetValue()}");
        }

        private void OnEnable()
        {
            //_onHealthChangedEvent.Register();
        }
    }
}
