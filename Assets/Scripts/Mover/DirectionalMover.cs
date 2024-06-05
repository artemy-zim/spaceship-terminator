using UnityEngine;

public class DirectionalMover : Mover
{
    [SerializeField] private Vector2 _direction;

    private Vector2 _normalizedDirection;

    private void Awake()
    {
        _normalizedDirection = _direction.normalized;
    }

    private void Update()
    {
        Move();
    }

    protected override void Move()
    {
        transform.Translate(Speed * Time.deltaTime * _normalizedDirection);
    }
}
