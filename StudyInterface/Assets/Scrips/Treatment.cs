using UnityEngine;

public class Treatment : MonoBehaviour
    {
        [SerializeField] private Player _player;

        public void OnClickButton()
        {
            _player.TakeHeal(10);
        }
    }
