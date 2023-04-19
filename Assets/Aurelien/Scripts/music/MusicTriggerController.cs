using System.Collections;
using UnityEngine;

public class MusicTriggerController : MonoBehaviour
{
    public AudioSource audioSource;
    public float fadeInDuration = 1f;
    public float fadeOutDuration = 1f;

    private bool isInsideTrigger = false;
    private float initialVolume;

    private void Start()
    {
        initialVolume = audioSource.volume;
        audioSource.volume = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isInsideTrigger)
        {
            isInsideTrigger = true;
            StopAllCoroutines();
            StartCoroutine(FadeIn());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && isInsideTrigger)
        {
            isInsideTrigger = false;
            StopAllCoroutines();
            StartCoroutine(FadeOut());
        }
    }

    private IEnumerator FadeIn()
    {
        audioSource.Play();

        float elapsed = 0;
        while (elapsed < fadeInDuration)
        {
            elapsed += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(0, initialVolume, elapsed / fadeInDuration);
            yield return null;
        }

        audioSource.volume = initialVolume;
    }

    private IEnumerator FadeOut()
    {
        float elapsed = 0;
        while (elapsed < fadeOutDuration)
        {
            elapsed += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(initialVolume, 0, elapsed / fadeOutDuration);
            yield return null;
        }

        audioSource.volume = 0;
        audioSource.Stop();
    }
}