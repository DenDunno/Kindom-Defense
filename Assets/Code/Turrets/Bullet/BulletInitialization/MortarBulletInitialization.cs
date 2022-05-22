
public class MortarBulletInitialization : IBulletInitialization
{
    private readonly IFactory<Particle> _explosionsPool;
    private readonly IFactory<Particle> _trailPool;

    public MortarBulletInitialization(IFactory<Particle> explosionsPool, IFactory<Particle> trailPool)
    {
        _explosionsPool = explosionsPool;
        _trailPool = trailPool;
    }
    
    public void Execute(Bullet bullet)
    {
        ((MortarBullet)bullet).Init(_explosionsPool, _trailPool.Create());
    }
}