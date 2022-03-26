using BehaviorDesigner.Runtime;

[System.Serializable]
public class SharedHealth : SharedVariable<Health>
{
    public static implicit operator SharedHealth(Health value) { return new SharedHealth { mValue = value }; }
}