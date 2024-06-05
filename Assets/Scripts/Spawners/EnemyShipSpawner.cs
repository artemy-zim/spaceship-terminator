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

    public event Action<EnemyShip> OnShipSpawned;

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

    protected override void Spawn()
    {
        EnemyShip enemyShip = Pool.GetObject();

        enemyShip.transform.position = GetPosition();
        enemyShip.OnSpawn();
        enemyShip.OnHit += Release;

        OnShipSpawned?.Invoke(enemyShip);
    }

    private Vector2 GetPosition()
    {
        float positionY = Random.Range(_lowerBound, _upperBound);

        return new Vector2(transform.position.x, positionY);
    }

    protected override void Release(EnemyShip enemyShip)
    {
        enemyShip.OnHit -= Release;
        base.Release(enemyShip);
    }

    public override void Reset()
    {
        base.Reset();   
        StopAllCoroutines();
        StartCoroutine(OnSpawnCoroutine());
    }
}
