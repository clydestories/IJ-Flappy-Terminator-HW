using UnityEngine;
using UnityEngine.Pool;

public abstract class Pool<T> : MonoBehaviour where T : Component
{
    [SerializeField] private T _prefab;
    [SerializeField] private int _defaultCapacity;
    [SerializeField] private int _maxSize;

    protected ObjectPool<T> ObjectPool;

    private void Awake()
    {
        ObjectPool = new ObjectPool<T>
            (
                createFunc: OnCreate,
                actionOnGet: OnGet,
                actionOnRelease: OnRelease,
                actionOnDestroy: (obj) => Destroy(obj),
                collectionCheck: false,
                defaultCapacity: _defaultCapacity,
                maxSize: _maxSize
            );
    }

    public virtual T Get(Vector2 origin, Vector2 direction)
    {
        return ObjectPool.Get();
    }

    public void Release(T bullet)
    {
        ObjectPool.Release(bullet);
    }

    protected virtual void OnGet(T bullet)
    {
        bullet.gameObject.SetActive(true);
    }

    private T OnCreate()
    {
        return Instantiate(_prefab, Vector2.zero, Quaternion.identity);
    }

    private void OnRelease(T bullet)
    {
        bullet.gameObject.SetActive(false);
    }
}
