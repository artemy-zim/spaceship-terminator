using System;

public class PlayerShot : InteractableObject, ISpawnable
{
    public event Action<PlayerShot> OnHit;
    public event Action OnEnemyHit;

    protected override void ProcessTrigger(IInteractable interactable)
    {
        if (interactable is EnemyShip)
        {
            OnEnemyHit?.Invoke();
            OnHit?.Invoke(this);
        }
        else if(interactable is FleeZone)
        {
            OnHit?.Invoke(this);
        }
    }

    public void OnSpawn()
    {
        gameObject.SetActive(true);
    }
}
