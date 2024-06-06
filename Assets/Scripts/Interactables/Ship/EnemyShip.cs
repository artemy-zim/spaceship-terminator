using System;
using UnityEngine;

public class EnemyShip : InteractableObject, ISpawnable
{
    [SerializeField] private ShotPoint _shotPoint;

    public event Action<EnemyShip> Hit;

    public Vector2 ShotPointPosition => _shotPoint.transform.position;

    public void OnSpawn()
    {
        gameObject.SetActive(true);
    }

    protected override void ProcessTrigger(IInteractable interactable)
    {
        if (interactable is PlayerShot || interactable is FleeZone)
            Hit?.Invoke(this);
    }
}
