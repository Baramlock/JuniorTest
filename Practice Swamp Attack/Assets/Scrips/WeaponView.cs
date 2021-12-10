using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WeaponView :MonoBehaviour
    {
    [SerializeField] private TMP_Text _lable;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Image _icon;

    [SerializeField] private Button _sellBotton;

    public event UnityAction<Weapon,WeaponView> SellButtonClick;
    private Weapon _weapon;

    public void Render(Weapon weapon)
    {
        _weapon = weapon;

        _price.text = weapon.Price.ToString();
        _lable.text = weapon.Lable;
        _icon.sprite = weapon.Icon;
    }

    private void TruLockItem()
    {
        if (_weapon.IsBueyed)
        {
            _sellBotton.interactable = false;
        }
    }

    private void OnButtonClick()
    {
        SellButtonClick?.Invoke(_weapon, this);
    }

    private void OnEnable()
    {
        _sellBotton.onClick.AddListener(OnButtonClick);
        _sellBotton.onClick.AddListener(TruLockItem);
    }
    private void OnDisable()
    {
        _sellBotton.onClick.RemoveListener(OnButtonClick);
        _sellBotton.onClick.RemoveListener(TruLockItem);
    }
}
