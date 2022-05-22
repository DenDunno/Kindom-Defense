
public class GatlingBulletInitialization : IBulletInitialization
{
    public void Execute(Bullet bullet)
    {
        ((GatlingBullet)bullet).Init();
    }
}