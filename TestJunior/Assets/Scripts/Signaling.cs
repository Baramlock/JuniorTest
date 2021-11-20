using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] float _volumeUpTime;

    private int _counterCollision;
    private Coroutine _coroutineIncreaseVolume;
    private WaitForSeconds _waitForSecond;

    private void Start()
    {
        _waitForSecond = new WaitForSeconds(1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.TryGetComponent<Player>(out Player player))
        {

            _counterCollision++;
            if (_counterCollision % 2 != 0)
            {
                _audio.Play();
                _audio.loop = true;
                _coroutineIncreaseVolume = StartCoroutine(IncreaseVolume());
            }
            else
            {
                _audio.Stop();
                _audio.volume = 0;
                StopCoroutine(_coroutineIncreaseVolume);
                _audio.loop = false;
            }
        }
    }

    private IEnumerator IncreaseVolume()
    {
        for (int i = 1; i < _volumeUpTime + 1; i++)
        {
            _audio.volume = i / _volumeUpTime;
            yield return _waitForSecond;
        }
    }
}
