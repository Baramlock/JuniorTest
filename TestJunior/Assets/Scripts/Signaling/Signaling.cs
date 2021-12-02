using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

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
        if (collision.TryGetComponent<Player>(out var player))
        {
            if (_audio.isPlaying == false)
                _audio.Play();
            _counterCollision++;
            RestartCoroutines(_counterCollision % 2);
        }
    }

    private void RestartCoroutines(float audioVolume)
    {
        if (_changeVolume != null)
            StopCoroutine(_changeVolume);
        _changeVolume = StartCoroutine(ChangeSoundGradual(audioVolume));
    }
    
    private IEnumerator ChangeSoundGradual(float audioVolume)
    {
        audioVolume = Mathf.Clamp01(audioVolume);
        var waitForSeconds = new WaitForSeconds(1);
        
        while (Math.Abs(audioVolume - _audio.volume) > 0.01)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, audioVolume, ((float)1 / _soundChangeTime));
            yield return waitForSeconds;
        }
        if (_audio.volume == 0)
            _audio.Stop();
    }
}