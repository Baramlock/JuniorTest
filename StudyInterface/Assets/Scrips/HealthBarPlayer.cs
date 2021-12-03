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
            _slider.DOValue(_player.Сharacteristics.Health / _player.Сharacteristics.MaxHealth, 1);
        }
    }
}