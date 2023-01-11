using System;
using DefaultNamespace.ScriptableEvents;
using TMPro;
using UnityEngine;
using Variables;
using Variables;

namespace UI
{
    public class UI : MonoBehaviour
    {
        [Header("Health:")]
        [SerializeField] private IntVariable _healthVar;
        [SerializeField] private TextMeshProUGUI _healthText;
        [SerializeField] private ScriptableEventIntReference _onHealthChangedEvent;
        
        [Header("Score:")]
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private IntVariable _asteroidsDestroyed;
        [SerializeField] private ScriptableEventIntReference _onAsteroidDestroyed;
        
        
        [Header("Timer:")]
        [SerializeField] private TextMeshProUGUI _timerText;
        [SerializeField] private FloatVariable _timePassed;
        
        [Header("Laser:")]
        [SerializeField] private TextMeshProUGUI _laserText;
        [SerializeField] private IntVariable _lasersFired;
        
        private void Start()
        {
            SetHealthText($"Health: {_healthVar.Value}");
        }

        public void OnHealthChanged(IntReference newValue)
        {
            SetHealthText($"Health: {newValue.GetValue()}");
        }

        private void SetHealthText(string text)
        {
            _healthText.text = text;
        }
        
        private void SetScoreText(string text)
        {
            _scoreText.text = text;
        }
        public void OnAsteroidDestroyed(IntReference newValue)
        {
            SetScoreText($"AsteroidsDestroyed: {newValue.GetValue()}");
        }
        
        private void SetTimerText(string text)
        {
            _timerText.text = text;
        }
        
        private void SetLaserText(string text)
        {
            _laserText.text = text;
        }
    }
}
