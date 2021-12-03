using UnityEngine;

    public class DealDamage : MonoBehaviour
    {
        [SerializeField] private Player _player;

        public void OnClickButton()
        {
            _player.Сharacteristics.TakeDamage(10f);
        }
    }
