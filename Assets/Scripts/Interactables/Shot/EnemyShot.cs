using System;

public class EnemyShot : InteractableObject, ISpawnable
{
    public event Action<EnemyShot> Hit;

    public void OnSpawn()
    {
        gameObject.SetActive(true);
    }

    protected override void ProcessTrigger(IInteractable interactable)
    {
        if(interactable is FleeZone)
            Hit?.Invoke(this);
    }
}
