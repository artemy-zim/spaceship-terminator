using System;
using UnityEngine;

public class EnemyShip : InteractableObject, ISpawnable
{
    [SerializeField] private ShotPoint _shotPoint;

    public Vector2 ShotPointPosition => _shotPoint.transform.position;

    public event Action<EnemyShip> OnHit;

    protected override void ProcessTrigger(IInteractable interactable)
    {
        if (interactable is PlayerShot || interactable is FleeZone)
            OnHit?.Invoke(this);
    }

    public void OnSpawn()
    {
        gameObject.SetActive(true);
    }
}
