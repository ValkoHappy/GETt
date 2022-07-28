using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Audio : MonoBehaviour
{

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float speed;
    [SerializeField] private float _maximumVolume;
    [SerializeField] private float _minimunVolume;
    [SerializeField] private UnityEvent _reached;
    [SerializeField] private float _target;
    private Coroutine _fadeInJob;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _reached.Invoke();
            WorkCoroutine();
        }
    }

    private IEnumerator FadeIn(float target)
    {
        while(_audioSource.volume != target)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, target, speed * Time.deltaTime);
            yield return null;
        }
    }

    private void WorkCoroutine()
    {
        if(_fadeInJob != null)
        {
            StopCoroutine(_fadeInJob);
        }
        else
        {
            StartCoroutine(FadeIn(100f));
        }
    }
}
