using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float speed;
    [SerializeField] private float _maximumVolume;
    [SerializeField] private float _minimunVolume;
    private Coroutine _fadeInJob;
    private float _target = 1f;

    private void Start()
    {
        _audioSource.volume = _minimunVolume;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _audioSource.Play();
        StartCoroutine(FadeIn());
    }

    private void ChangeVolume()
    { 
        if (_audioSource.volume == 1f)
        {
            _target = 0f;
        }
        else if (_audioSource.volume == 0f)
        {
            _target = 1f;
        }
    }

    private IEnumerator FadeIn()
    {
        while (_audioSource.volume != _target)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _target, speed * Time.deltaTime);
            ChangeVolume();
            yield return null;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _audioSource.Stop();
        StopCoroutine(FadeIn());
    }
}

