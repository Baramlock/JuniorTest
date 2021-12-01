using System;
using System.Collections;
using UnityEngine;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private int _soundChangeTime = 20;

    private int _counterCollision;
    private Coroutine _changeVolume;

    private void Start()
    {
        _audio.volume = 0;
        _audio.loop = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _audio.Play();
            if (_counterCollision % 2 == 0)
                RestartCorutine(true);
            else
                RestartCorutine(false);
            _counterCollision++;
        }
    }

    private void RestartCorutine(bool isIncrease)
    {
        if (_changeVolume != null)
            StopCoroutine(_changeVolume);
        _changeVolume = StartCoroutine(ChangeSoundGradual(isIncrease));
    }

    private IEnumerator ChangeSoundGradual(bool isIncrease)
    {
        WaitForSeconds _waitForSeconds = new WaitForSeconds(1);

        while (true)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, Convert.ToInt32(isIncrease), ((float)1 / _soundChangeTime));
            if (_audio.volume <= 0)
            {
                _audio.Stop();
                yield break;
            }
            if (_audio.volume >= 1)
            {
                yield break;
            }
            yield return _waitForSeconds;
        }
    }
}
