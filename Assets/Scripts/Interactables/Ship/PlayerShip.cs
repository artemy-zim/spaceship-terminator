using System;
using UnityEngine;

public class PlayerShip : InteractableObject
{
    [SerializeField] private ForceMover _shipMover;

    public event Action OnGameOver;

    protected override void ProcessTrigger(IInteractable interactable)
    {
        if (interactable is not PlayerShot)
            OnGameOver?.Invoke();
    }

    public void Reset()
    {
        _shipMover.Reset();
    }
}
