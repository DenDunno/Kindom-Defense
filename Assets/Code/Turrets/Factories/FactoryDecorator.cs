
public abstract class FactoryDecorator<T> : IFactory<T>
{
    private readonly IFactory<T> _factory;

    protected FactoryDecorator(IFactory<T> factory)
    {
        _factory = factory;
    }
    
    public T Create()
    {
        T createdObject = _factory.Create();
        OnCreate(createdObject);

        return createdObject;
    }

    protected abstract void OnCreate(T createdObject);
}