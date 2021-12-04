using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Player _player;
    
  private void OnEnable()
  {
      _player.HealthChanged += ChangeHealth;
  }

  private void OnDisable()
  {
      _player.HealthChanged -= ChangeHealth;
  }

  private void ChangeHealth(float health)
  {
      _slider.DOValue(health / _player.MaxHealth, 1);
  }
}