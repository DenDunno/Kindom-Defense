
public class TurretFactory : FactoryDecorator<Turret>
{
    private readonly IFactory<Bullet> _bulletFactory;

    public TurretFactory(IFactory<Turret> factory, IFactory<Bullet> bulletFactory) : base(factory)
    {
        _bulletFactory = bulletFactory;
    }

    protected override void OnCreate(Turret turret)
    {
        turret.Init(_bulletFactory);
    }
}