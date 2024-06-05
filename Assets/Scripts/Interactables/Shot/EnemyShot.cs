using System;

public class EnemyShot : InteractableObject, ISpawnable
{
    public event Action<EnemyShot> OnHit;

    protected override void ProcessTrigger(IInteractable interactable)
    {
        if(interactable is FleeZone)
            OnHit?.Invoke(this);
    }

    public void OnSpawn()
    {
        gameObject.SetActive(true);
    }
}
