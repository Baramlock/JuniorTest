using UnityEngine;

public class Treatment : MonoBehaviour
    {
        [SerializeField] private Player _player;

        public void OnClickButton()
        {
            _player.Healths.TakeHeal(10);
        }
    }
