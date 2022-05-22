
public class MortarBulletInitialization : IBulletInitialization
{
    private readonly IFactory<Particle> _explosionsPool;

    public MortarBulletInitialization(IFactory<Particle> explosionsPool)
    {
        _explosionsPool = explosionsPool;
    }
    
    public void Execute(Bullet bullet)
    {
        ((MortarBullet)bullet).Init(_explosionsPool);
    }
}