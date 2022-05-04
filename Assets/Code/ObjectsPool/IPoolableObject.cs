
public interface IPoolableObject
{
    bool IsActive { get; }
    void ResetObject();
}