using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private Weapon _startWeapon;

    public UnityAction<int> HealthChanger;

    public int Money { get;private set; }

    private List<Weapon> _weapons;
    private Weapon _currentWeapon;



    private void Start()
    {
        _weapons = new List<Weapon>() {_startWeapon};
        _currentWeapon = _weapons[0];
        HealthChanger?.Invoke(_health);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _currentWeapon.Attack();
        }
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;
        HealthChanger?.Invoke(_health);

        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void AddMoney(int money)
    {
        Money += money;
    }
}
