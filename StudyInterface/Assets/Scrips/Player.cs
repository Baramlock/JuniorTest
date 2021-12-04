using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [Range(1,500)]
    [SerializeField] private float _maxHealth = 100;
    [Range(0,500)]
    [SerializeField] private float _health = 100;
    
    public float MaxHealth => _maxHealth;
    public float Health => _health;
    public event UnityAction<float> HealthChanged;

    private void Start()
    {
        HealthChanged?.Invoke(_health);
        if (_health > _maxHealth) 
            _health = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        var tagDamage = damage > 0 ? damage : 0;
        if(tagDamage == 0)
            Debug.Log("Attack value must be greater than 0");
        if (tagDamage > _health) 
            _health = 0;
        else 
            _health -= tagDamage;
        HealthChanged?.Invoke(_health);
    }

    public void TakeHeal(float health)
    {
        var tagHealth = health > 0 ? health : 0;
        if(health == 0)
            Debug.Log("Health value must be greater than 0");
        if (tagHealth > _maxHealth - _health)
            _health = _maxHealth;
        else
            _health += tagHealth;
        HealthChanged?.Invoke(_health);
    }
}

