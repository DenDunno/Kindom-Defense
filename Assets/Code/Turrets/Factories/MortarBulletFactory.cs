
public class MortarBulletFactory : FactoryDecorator<MortarBullet>
{
    private readonly IFactory<Particle> _explosionsFactory;

    public MortarBulletFactory(IFactory<MortarBullet> factory, IFactory<Particle> explosionsFactory) : base(factory)
    {
        _explosionsFactory = explosionsFactory;
    }

    protected override void OnCreate(MortarBullet mortarBullet)
    {
        mortarBullet.Init(_explosionsFactory);
    }
}