using System;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private string _lable;
    [SerializeField] private Sprite _icon;
    [SerializeField] private int _price;
    
    [SerializeField] protected int _damage;
    [SerializeField] protected int Delay;
    [SerializeField] protected Animator _animator;
    [SerializeField] protected Bullet _bullet;

    protected float LastAttackTime;
    public int Damage => _damage;

    public abstract void Attack();
}
