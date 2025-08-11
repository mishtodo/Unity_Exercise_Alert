using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alert : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _currentVolume = 0f;
    [SerializeField] private float _targetVolume = 0f;

    private Coroutine _coroutine;
    private float _maxVolume = 1.0f;
    private float _minVolume = 0.0f;
    private float _volumeStep = 0.3f;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.loop = true;
        _audioSource.Play();
    }

    private void Start()
    {
        StartCoroutine();
    }

    public void RaiseVolume()
    {
        _targetVolume = _maxVolume;
    }

    public void LowerVolume()
    {
        _targetVolume = _minVolume;
    }

    public void StopCoroutine()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private void StartCoroutine()
    {
        _coroutine = StartCoroutine(ChangeVolumeSmootly());
    }

    private IEnumerator ChangeVolumeSmootly()
    {
        while (enabled)
        {
            _audioSource.volume = Mathf.MoveTowards(_currentVolume, _targetVolume, _volumeStep * Time.deltaTime);
            _currentVolume = _audioSource.volume;
            yield return null;
        }
    }
}