using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour 
{
    [SerializeField] private T _prefab;
    [SerializeField] private Transform _container;

    private Queue<T> _pool;

    private void Awake()
    {
        _pool = new Queue<T>();
    }

    public T GetObject()
    {
        if(_pool.Count == 0)
        {
            var spawnable = Instantiate(_prefab);
            spawnable.transform.parent = _container;

            return spawnable;
        }

        return _pool.Dequeue();
    }

    public void PutObject(T spawnable)
    {
        _pool.Enqueue(spawnable);
        spawnable.gameObject.SetActive(false);
    }

    public void Reset()
    {
        _pool.Clear();

        foreach(Transform child in _container)
            Destroy(child.gameObject);
    }
}
