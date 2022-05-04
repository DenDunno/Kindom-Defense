
public class PoolableObject : IUpdatable
{
    private readonly IPoolableObject _poolableObject;

    public PoolableObject(IPoolableObject poolableObject)
    {
        _poolableObject = poolableObject;
    }

    public bool IsActive { get; private set; }

    public void Update()
    {
     //   IsActive = _poolableObject.IsActive();
    }

    public void Reset()
    {
        IsActive = true;
        //_poolableObject.ResetObject();
    }
}