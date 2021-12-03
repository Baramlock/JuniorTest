using UnityEngine;

public class Player : MonoBehaviour
{
    public Сharacteristics Сharacteristics { get; private set; }

    private void Start()
    {
        Сharacteristics = new Сharacteristics(200,100);
    }
}

public class Сharacteristics
{
    public float MaxHealth { get; }

    private float _health;
    public float Health
    {
        get => _health;
        private set => _health = value > MaxHealth ? MaxHealth : value;
    }

    public Сharacteristics(float maxHealth, float health)
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
