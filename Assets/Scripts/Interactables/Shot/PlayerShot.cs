using System;

public class PlayerShot : InteractableObject, ISpawnable
{
    public event Action<PlayerShot> Hit;
    public event Action EnemyHit;

    public void OnSpawn()
    {
        gameObject.SetActive(true);
    }

    protected override void ProcessTrigger(IInteractable interactable)
    {
        if (interactable is EnemyShip)
        {
            EnemyHit?.Invoke();
            Hit?.Invoke(this);
        }
        else if(interactable is FleeZone)
        {
            Hit?.Invoke(this);
        }
    }
}
