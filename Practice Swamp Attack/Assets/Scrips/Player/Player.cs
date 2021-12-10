using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private Weapon _startWeapon;
    [SerializeField] private Transform _shootPoint;

    public UnityAction<int> HealthChanger;

    public int Money { get; private set; }

    [SerializeField] private List<Weapon> _weapons;
    private int _currentWeaponIndex;
    private Weapon _currentWeapon;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _weapons = new List<Weapon>() { _startWeapon};
        _currentWeaponIndex = 0;
        _currentWeapon = _weapons[0];
        _currentWeapon.Init(_animator);
        HealthChanger?.Invoke(_health);
    }

    private void Update()   
    {
        if (Input.GetMouseButtonDown(0))
        {
            _currentWeapon.Attack(_shootPoint);
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

    public void BuyWeapon(Weapon weapon)
    {
        Money -= weapon.Price;
        _weapons.Add(weapon);
    }

    public void NextWeapon()
    {
        if (_currentWeaponIndex < _weapons.Count - 1)
        {
            ChangeWeapon(_currentWeaponIndex + 1);
            _currentWeapon.Init(_animator);
            _currentWeapon.PlayAnimation();
        }
        else
        {
            ChangeWeapon(0);
            _currentWeapon.Init(_animator);
            _currentWeapon.PlayAnimation();
        }
    }

    private void ChangeWeapon(int index)
    {
        _currentWeaponIndex = index;
        _currentWeapon = _weapons[index];
    }
}