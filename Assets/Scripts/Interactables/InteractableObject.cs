using UnityEngine;

public abstract class InteractableObject : MonoBehaviour, IInteractable
{
    [SerializeField] private TriggerHandler _triggerHandler;

    private void OnEnable()
    {
        _triggerHandler.OnTriggerEntered += ProcessTrigger;
    }

    private void OnDisable()
    {
        _triggerHandler.OnTriggerEntered -= ProcessTrigger;
    }

    protected abstract void ProcessTrigger(IInteractable interactable);
}
