using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Player _player;
    
  private void OnEnable()
  {
      _player.HealthChanger += HealthChanger;
  }

  private void OnDisable()
  {
      _player.HealthChanger -= HealthChanger;
  }

  private void HealthChanger(float health)
  {
      _slider.DOValue(health / _player.MaxHealth, 1);
  }
}