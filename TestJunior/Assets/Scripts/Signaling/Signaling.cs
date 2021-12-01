using System.Collections;
using UnityEngine;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private int _soundChangeTime = 20;

    private WaitForSeconds _waitForSeconds;
    private int _counterCollision;
    private Coroutine _coroutineIncreaseVolume;
    private Coroutine _coroutineDecreaseVolume;

    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(1);
        _audio.volume = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            if (_counterCollision % 2 == 0)
            {
                if (_audio.isPlaying)
                {
                    StopCoroutine(_coroutineDecreaseVolume);
                    _coroutineIncreaseVolume = StartCoroutine(IncreaseVolume());
                }
                else
                {
                    _audio.Play();
                    _audio.loop = true;
                    _coroutineIncreaseVolume = StartCoroutine(IncreaseVolume());
                }
            }
            else
            {
                StopCoroutine(_coroutineIncreaseVolume);
                _coroutineDecreaseVolume = StartCoroutine(DecreaseVolume());
            }
            _counterCollision++;
        }
    }

    private IEnumerator IncreaseVolume()
    { 
        for (int i = 1; i < _soundChangeTime + 1; i++)
        {
            _audio.volume = (float)i / _soundChangeTime;
            yield return _waitForSeconds;
        }
    }

    private IEnumerator DecreaseVolume()
    {
        for (int i = (int)(_audio.volume * _soundChangeTime); i >= 0 ; i--)
        {
            _audio.volume = (float)i / _soundChangeTime;
            if (i == 0)
            {
                _audio.Stop();
                _audio.loop = false;
            }
            yield return _waitForSeconds;
        }
    }

}
