using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public HealthPlayer HealthPlayer;
    
    private void Start()
    {
        HealthPlayer = new HealthPlayer(200,100);
    }
}

public class HealthPlayer
{
    public float MaxHealth { get; }

    private float _health;
    public float Health
    {
        get { return _health; }
        set { _health = value > MaxHealth ? MaxHealth : value; }
    }

    public HealthPlayer(float maxHealth, float health)
    {
        MaxHealth = maxHealth;
        Health = health;
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
    }

    public void TakeHeal(float health)
    {
        Health += health;
    }
}
