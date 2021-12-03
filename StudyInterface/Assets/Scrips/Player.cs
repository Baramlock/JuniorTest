using UnityEngine;

public class Player : MonoBehaviour
{
    public Healths Healths { get; private set; }

    private void Start()
    {
        Healths = new Healths(200,100);
    }
}

public class Healths
{
    public readonly float MaxHealth;
    public float Health { get; private set; }

    public Healths(float maxHealth, float health)
    {
        MaxHealth = maxHealth <= 0 ? 100 : maxHealth;
        Health = health < 0 && health > MaxHealth ? maxHealth : health;
    }

    public void TakeDamage(float damage)
    {
        var tagDamage = damage > 0 ? damage : 0;
        if (tagDamage > Health) 
            Health = 0;
        else 
            Health -= tagDamage;
    }

    public void TakeHeal(float health)
    {
        var tagHealth = health > 0 ? health : 0;
        if (tagHealth > MaxHealth - Health)
            Health = MaxHealth;
        else
            Health += tagHealth;
    }
}
