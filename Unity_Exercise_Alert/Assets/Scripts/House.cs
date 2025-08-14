using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private Alert _alert;
    [SerializeField] private AlertZone _alertZone;

    private float _maxAlertVolume = 1.0f;
    private float _minAlertVolume = 0.0f;

    private void OnEnable()
    {
        _alertZone.EnterTresspassing += RaiseVolume;
        _alertZone.ExitTresspassing += LowerVolume;
    }

    private void OnDisable()
    {
        _alertZone.EnterTresspassing -= RaiseVolume;
        _alertZone.ExitTresspassing -= LowerVolume;
    }

    private void RaiseVolume()
    {
        _alert.StopCoroutine();
        _alert.StartCoroutine(_maxAlertVolume);
    }

    private void LowerVolume()
    {
        _alert.StopCoroutine();
        _alert.StartCoroutine(_minAlertVolume);
    }
}