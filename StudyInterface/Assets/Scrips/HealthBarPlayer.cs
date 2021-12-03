using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Scrips
{
    public class HealthBarPlayer : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private Player _player;
        private void Update()
        {
            _slider.DOValue(_player.HealthPlayer.Health / _player.HealthPlayer.MaxHealth, 1);
        }
    }
}