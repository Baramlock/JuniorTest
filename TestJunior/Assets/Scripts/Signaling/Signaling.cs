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
        if (collision.TryGetComponent<Player>(out _))
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

    private IEnumerator ChangeSoundGradual(float targetVolume)
    {
        targetVolume = Mathf.Clamp01(targetVolume);
        var waitForSeconds = new WaitForSeconds(1);
        
        while (targetVolume == _audio.volume)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, targetVolume, ((float)1 / _soundChangeTime));
            yield return waitForSeconds;
        }
        if (_audio.volume == 0)
            _audio.Stop();
    }
}