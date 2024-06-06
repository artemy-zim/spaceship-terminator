using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class ForceMover : Mover
{
    [SerializeField] private InputImpulse _input;

    [SerializeField] private float _force;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _minRotationZ;
    [SerializeField] private float _maxRotationZ;

    private Rigidbody2D _rigidbody;
    private Quaternion _minRotation;
    private Quaternion _maxRotation;
    private Vector2 _startPosition;

    private void OnValidate()
    {
        if(_minRotationZ > _maxRotationZ)
            _minRotationZ = _maxRotationZ;
    }

    private void Awake()
    {
        _minRotation = Quaternion.Euler(0f, 0f, _minRotationZ);
        _maxRotation = Quaternion.Euler(0f, 0f, _maxRotationZ);
        _rigidbody = GetComponent<Rigidbody2D>();

        _startPosition = transform.position;
    }

    private void OnEnable()
    {
        _input.Executed += Move;
    }

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    private void OnDisable()
    {
        _input.Executed -= Move;
    }

    public void Reset()
    {
        _rigidbody.velocity = Vector2.zero;
        transform.SetPositionAndRotation(_startPosition, Quaternion.identity);
    }

    protected override void Move()
    {
        _rigidbody.velocity = new Vector2(Speed, _force);
        transform.rotation = _maxRotation;
    }
}
