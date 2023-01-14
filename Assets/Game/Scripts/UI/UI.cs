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
        [SerializeField] private ScriptableEvent _onHealthChangedEvent;
        
        [Header("Score:")]
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private IntVariable _asteroidsDestroyed;
        [SerializeField] private ScriptableEvent _onAsteroidDestroyed;
        
        [Header("Timer:")]
        [SerializeField] private TextMeshProUGUI _timerText;
        [SerializeField] private IntVariable _timeLeft;
        [SerializeField] private ScriptableEvent _onTimePassed;
        
        [Header("Laser:")]
        [SerializeField] private TextMeshProUGUI _laserText;
        [SerializeField] private IntVariable _lasersFired;
        [SerializeField] private ScriptableEvent _onLaserFired;
        
        private void Start()
        {
            SetHealthText($"Health: {_healthVar.CurrentValue}");
            SetScoreText($"Asteroids Destroyed: {_asteroidsDestroyed.CurrentValue}");
            SetTimerText($"Time Left: {_timeLeft.CurrentValue}");
            SetLaserText($"Lasers Fired: {_lasersFired.CurrentValue}");
            
        }

        // ------------HEALTH----------------
        
        private void SetHealthText(string text)
        {
            _healthText.text = text;
        }
        public void OnHealthChanged(IntVariable newValue)
        {
            SetHealthText($"Health: {newValue.CurrentValue}");
        }

        // ------------SCORE----------------
        
        private void SetScoreText(string text)
        {
            _scoreText.text = text;
        }
        public void OnAsteroidDestroyed(IntVariable newValue)
        {
            SetScoreText($"Asteroids Destroyed: {newValue.CurrentValue}");
        }
        
        // ------------TIMER----------------
        
        private void SetTimerText(string text)
        {
            _timerText.text = text;
        }
        public void OnTimePassed(IntVariable newValue)
        {
            SetTimerText($"Time Left: {newValue.CurrentValue}");
        }
        
        // ------------LASERS----------------
        
        private void SetLaserText(string text)
        {
            _laserText.text = text;
        }
        public void OnLaserFired(IntVariable newValue)
        {
            SetLaserText($"Lasers Fired: {newValue.CurrentValue}");
        }
    }
}
