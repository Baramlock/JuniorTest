using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private string _lable;
    [SerializeField] private Sprite _icon;
    [SerializeField] private int _price;
    [SerializeField] private bool _isBueyed = false;
    private Animator _animator;

    [SerializeField] protected int _damage;
    [SerializeField] protected int Delay;
    [SerializeField] protected Bullet _bullet;

    protected float LastAttackTime;
    protected Animator Animator => _animator;
    public int Damage => _damage;
    public string Lable => _lable;
    public Sprite Icon => _icon;
    public int Price => _price;
    public bool IsBueyed => _isBueyed;

    public abstract void Attack(Transform shootPoint);

    public void Buy() => _isBueyed = true;

    public void Init(Animator animator)
    {
        _animator = animator;
    }

    public abstract void PlayAnimation();

    private void Update()
    {
        LastAttackTime -= Time.deltaTime;
    }
}
