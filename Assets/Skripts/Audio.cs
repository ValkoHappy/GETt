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

    private void Start()
    {
        var fadeInJob = StartCoroutine(FadeIn(1f));
    }

    private IEnumerator FadeIn(float target)
    {
        var waitForOneSeconds = new WaitForSeconds(1f);

        while(_audioSource.volume != target)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, target, speed * Time.deltaTime);
            yield return waitForOneSeconds;
        }
    }
}
