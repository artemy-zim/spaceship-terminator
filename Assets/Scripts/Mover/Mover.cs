using UnityEngine;

public abstract class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;

    public float Speed => _speed;

    protected abstract void Move();
}
    
