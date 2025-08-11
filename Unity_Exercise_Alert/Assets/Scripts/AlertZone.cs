using System;
using UnityEngine;

public class AlertZone : MonoBehaviour 
{
    public event Action EnterTresspassing;
    public event Action ExitTresspassing;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Thief>(out Thief thief))
        {
            EnterTresspassing?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<Thief>(out Thief thief))
        {
            ExitTresspassing?.Invoke();
        }
    }
}