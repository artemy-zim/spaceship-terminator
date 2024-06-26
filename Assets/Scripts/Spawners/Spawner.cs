using UnityEngine;

public abstract class Spawner<T> : MonoBehaviour where T : MonoBehaviour, ISpawnable
{
    [SerializeField] private ObjectPool<T> _pool;

    protected ObjectPool<T> Pool => _pool;

    public virtual void Reset()
    {
        _pool.Reset();
    }

    protected abstract void Spawn();

    protected virtual void Release(T spawnable)
    {
        _pool.PutObject(spawnable);
    }
}
