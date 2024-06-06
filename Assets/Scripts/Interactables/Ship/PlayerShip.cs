using System;
using UnityEngine;

public class PlayerShip : InteractableObject
{
    [SerializeField] private ForceMover _shipMover;

    public event Action GameOver;

    public void Reset()
    {
        _shipMover.Reset();
    }

    protected override void ProcessTrigger(IInteractable interactable)
    {
        if (interactable is not PlayerShot)
            GameOver?.Invoke();
    }
}
