using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Player _player;
    [SerializeField] private WeaponView _template;
    [SerializeField] private GameObject _itemContainer;

    private void Start()
    {
        foreach (var weapon in _weapons)
        {
            AddItem(weapon);
        }
    }

    private void AddItem(Weapon weapon)
    {
        var view = Instantiate(_template, _itemContainer.transform);
        view.SellButtonClick += OnSellButtonClick;
        view.Render(weapon);
    }

    private void OnSellButtonClick(Weapon weapon, WeaponView weaponView) => TrySellWeapon(weapon,weaponView);

    private void TrySellWeapon(Weapon weapon,WeaponView weaponView)
    {
        if (weapon.Price <= _player.Money)
        {
            var newWeapon = Instantiate(weapon, Vector3.zero, Quaternion.identity, _player.transform);
            _player.BuyWeapon(newWeapon);
            newWeapon.Buy();
            weaponView.SellButtonClick -= OnSellButtonClick;
            
        }
    }
}
