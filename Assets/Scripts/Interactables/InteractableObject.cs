using UnityEngine;

public abstract class InteractableObject : MonoBehaviour, IInteractable
{
    [SerializeField] private TriggerHandler _triggerHandler;

    private void OnEnable()
    {
        _triggerHandler.TriggerEntered += ProcessTrigger;
    }

    private void OnDisable()
    {
        _triggerHandler.TriggerEntered -= ProcessTrigger;
    }

    protected abstract void ProcessTrigger(IInteractable interactable);
}
