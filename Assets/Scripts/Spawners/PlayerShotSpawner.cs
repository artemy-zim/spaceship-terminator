using UnityEngine;

public class PlayerShotSpawner : Spawner<PlayerShot>
{
    [SerializeField] private ScoreCounter _score;
    [SerializeField] private InputShoot _input;
    [SerializeField] private ShotPoint _shotPoint;

    public override void Reset()
    {
        _score.Reset();
        base.Reset();
    }

    private void OnEnable()
    {
        _input.Executed += Spawn;
    }

    private void OnDisable()
    {
        _input.Executed -= Spawn;
    }

    protected override void Spawn()
    {
        PlayerShot shot = Pool.GetObject();

        shot.transform.SetPositionAndRotation(_shotPoint.transform.position, _shotPoint.transform.rotation);
        shot.OnSpawn();
        shot.Hit += Release;
        shot.EnemyHit += OnEnemyHit;
    }

    protected override void Release(PlayerShot shot)
    {
        shot.Hit -= Release;
        shot.EnemyHit -= OnEnemyHit;
        base.Release(shot);
    }

    private void OnEnemyHit()
    {
        _score.Add();
    }
}
