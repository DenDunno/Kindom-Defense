
public class GatlingBulletFactory : FactoryDecorator<GatlingBullet>
{
    public GatlingBulletFactory(IFactory<GatlingBullet> factory) : base(factory)
    {
    }

    protected override void OnCreate(GatlingBullet gatlingBullet)
    {
        gatlingBullet.Init();
    }
}