using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotSpawner : Spawner<EnemyShot>
{
    [SerializeField] private EnemyShipSpawner _shipSpawner;
    [SerializeField] private float _delay;
    [SerializeField] private float _startDelay;

    private readonly Dictionary<EnemyShip, Coroutine> _onShootCoroutines = new Dictionary<EnemyShip, Coroutine>();
    private Vector2 _nextPosition;

    public override void Reset()
    {
        StopAllCoroutines();
        _onShootCoroutines.Clear();
        base.Reset();
    }

    private void OnEnable()
    {
        _shipSpawner.ShipSpawned += OnShipSpawned;
    }

    private void OnDisable()
    {
        _shipSpawner.ShipSpawned -= OnShipSpawned;
    }

    protected override void Spawn()
    {
        EnemyShot shot = Pool.GetObject();

        shot.transform.position = _nextPosition;
        shot.OnSpawn();
        shot.Hit += Release;
    }

    protected override void Release(EnemyShot enemyShot)
    {
        enemyShot.Hit -= Release;
        base.Release(enemyShot);
    }

    private void OnShipSpawned(EnemyShip ship)
    {
        Coroutine coroutine = StartCoroutine(OnShootCoroutine(ship));
        UpdateShootCoroutine(coroutine, ship);
    }

    private void UpdateShootCoroutine(Coroutine coroutine, EnemyShip ship)
    {
        if (_onShootCoroutines.ContainsKey(ship))
        {
            if (_onShootCoroutines[ship] != null)
                StopCoroutine(_onShootCoroutines[ship]);

            _onShootCoroutines[ship] = coroutine;
        }
        else
        {
            _onShootCoroutines.Add(ship, coroutine);
        }
    }

    private IEnumerator OnShootCoroutine(EnemyShip ship)
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);
        yield return new WaitForSeconds(_startDelay);

        while (ship.isActiveAndEnabled)
        {
            _nextPosition = ship.ShotPointPosition;
            Spawn();

            yield return wait;
        }
    }
}
