using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alert : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _currentVolume = 0f;

    private Coroutine _coroutine;
    private float _volumeStep = 0.3f;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.loop = true;
        _audioSource.Play();
    }

    public void StopCoroutine()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    public void StartCoroutine(float targetVolume)
    {
        _coroutine = StartCoroutine(ChangeVolumeSmootly(targetVolume));
    }

    private IEnumerator ChangeVolumeSmootly(float targetVolume)
    {
        while (_currentVolume != targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_currentVolume, targetVolume, _volumeStep * Time.deltaTime);
            _currentVolume = _audioSource.volume;

            yield return null;
        }
    }
}