using UnityEngine;

public class Thief : MonoBehaviour 
{
    [SerializeField] private Alert _alert;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<AlertZone>(out AlertZone alertZone))
            _alert.RaiseVolume();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<AlertZone>(out AlertZone alertZone))
            _alert.LowerVolume();
    }
}