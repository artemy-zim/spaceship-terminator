using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyShipSpawner : Spawner<EnemyShip>
{
    [SerializeField] private float _delay;
    [SerializeField] private float _startDelay;
    [SerializeField] private float _upperBound;
    [SerializeField] private float _lowerBound;

    public event Action<EnemyShip> ShipSpawned;

    public override void Reset()
    {
        base.Reset();
        StopAllCoroutines();
        StartCoroutine(OnSpawnCoroutine());
    }

    protected override void Spawn()
    {
        EnemyShip enemyShip = Pool.GetObject();

        enemyShip.transform.position = GetPosition();
        enemyShip.OnSpawn();
        enemyShip.Hit += Release;

        ShipSpawned?.Invoke(enemyShip);
    }

    protected override void Release(EnemyShip enemyShip)
    {
        enemyShip.Hit -= Release;
        base.Release(enemyShip);
    }

    private IEnumerator OnSpawnCoroutine()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);
        yield return new WaitForSeconds(_startDelay);

        while (enabled)
        {
            Spawn();

            yield return wait;
        }
    }

    private Vector2 GetPosition()
    {
        float positionY = Random.Range(_lowerBound, _upperBound);

        return new Vector2(transform.position.x, positionY);
    }
}
