using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Player _player;

    private float _health;
    
    private void FixedUpdate()
    {
        if (Mathf.Approximately(_health,_player.Healths.Health) == false)
        {
            _slider.DOValue(_player.Healths.Health / _player.Healths.MaxHealth, 1);
            _health = _player.Healths.Health;
        }
    }
}