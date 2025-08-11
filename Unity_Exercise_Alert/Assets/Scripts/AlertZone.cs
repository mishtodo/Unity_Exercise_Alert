using UnityEngine;

public class AlertZone : MonoBehaviour 
{
    [SerializeField] private Alert _alert;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Thief>(out Thief thief))
        {
            _alert.RaiseVolume();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<Thief>(out Thief thief))
        {
            _alert.LowerVolume();
        }
    }
}