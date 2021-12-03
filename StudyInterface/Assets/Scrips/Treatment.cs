using UnityEngine;

namespace Scrips
{
    public class Treatment : MonoBehaviour
    {
        [SerializeField] private Player _player;

        public void OnClickButton()
        {
            _player.HealthPlayer.TakeHeal(10);
        }
    }
}