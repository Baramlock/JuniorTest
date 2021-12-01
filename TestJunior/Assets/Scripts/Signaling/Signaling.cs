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
            if (_audio.isPlaying == false)
                _audio.Play();
            if (_counterCollision % 2 == 0)
                RestartCorutine(1);
            else
                RestartCorutine(0);
            _counterCollision++;

        }
    }

    private void RestartCorutine(float audioVolume)
    {
        if (_changeVolume != null)
            StopCoroutine(_changeVolume);
        _changeVolume = StartCoroutine(ChangeSoundGradual(audioVolume));
    }

    private IEnumerator ChangeSoundGradual(float audioVolume)
    {
        audioVolume = Mathf.Clamp01(audioVolume);
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);

        while (true)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, audioVolume, ((float)1 / _soundChangeTime));
            if (audioVolume == _audio.volume)
            {
                if (_audio.volume == 0)
                    _audio.Stop();
                yield break;
            }
        }
    }
}
