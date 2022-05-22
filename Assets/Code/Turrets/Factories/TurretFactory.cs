
public class TurretFactory : FactoryDecorator<Turret>
{
    private readonly IFactory<Bullet> _bulletPool;
    private readonly IBulletInitialization _bulletInitialization;

    public TurretFactory(IFactory<Turret> factory, IFactory<Bullet> bulletPool, IBulletInitialization bulletInitialization) : base(factory)
    {
        _bulletPool = bulletPool;
        _bulletInitialization = bulletInitialization;
    }

    protected override void OnCreate(Turret turret)
    {
        turret.Init(_bulletPool, _bulletInitialization);
    }
}