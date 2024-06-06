using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class TriggerHandler : MonoBehaviour
{
    public event Action<IInteractable> TriggerEntered;

    private void OnValidate()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable interactable))
            TriggerEntered?.Invoke(interactable);
    }
}
