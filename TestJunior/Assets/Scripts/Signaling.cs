using UnityEngine;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] float _volumeUpTime;

    private bool _isSignaling;
    private float a;
    private int _counterCollision;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            a = 0;
            _audio.Play();
            _counterCollision++;
            if (_counterCollision % 2 == 0)
            {
                _audio.loop = false;
                _audio.Stop();
                
            }
            else
            {
                _audio.loop = true;
            }
        }
    }

    private void Update()
    {
        if (_audio.isPlaying)
        {
            a += Time.deltaTime;
            _audio.volume = (a / _volumeUpTime);
        }
    }
}
