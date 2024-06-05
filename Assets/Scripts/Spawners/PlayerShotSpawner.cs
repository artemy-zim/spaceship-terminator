using UnityEngine;

public class PlayerShotSpawner : Spawner<PlayerShot>
{
    [SerializeField] private ScoreCounter _score;
    [SerializeField] private InputShoot _input;
    [SerializeField] private ShotPoint _shotPoint;

    private void OnEnable()
    {
        _input.OnExecuted += Spawn;
    }

    private void OnDisable()
    {
        _input.OnExecuted -= Spawn;
    }

    protected override void Spawn()
    {
        PlayerShot shot = Pool.GetObject();

        shot.transform.SetPositionAndRotation(_shotPoint.transform.position, _shotPoint.transform.rotation);
        shot.OnSpawn();
        shot.OnHit += Release;
        shot.OnEnemyHit += HandleEnemyHit;
    }

    private void HandleEnemyHit()
    {
        _score.Add();
    }

    protected override void Release(PlayerShot shot)
    {
        shot.OnHit -= Release;
        shot.OnEnemyHit -= HandleEnemyHit;
        base.Release(shot);
    }

    public override void Reset()
    {
        _score.Reset();
        base.Reset();
    }
}
