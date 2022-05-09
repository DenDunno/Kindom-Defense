using UnityEngine;

public class MortarHeadRotationToEnemy : IWeaponHeadRotationToEnemy
{
    private readonly WeaponRadar _weaponRadar;
    private readonly Transform _head;
    private const float _minAngle = -35;
    
    public MortarHeadRotationToEnemy(WeaponRadar weaponRadar, Transform head)
    {
        _weaponRadar = weaponRadar;
        _head = head;
    }

    public float Angle
    {
        get
        {
            Vector3 startPosition = _head.transform.position;
            Vector3 targetPosition = _weaponRadar.Target.position;
            startPosition.y = 0;
            targetPosition.y = 0;
            float distance = Vector3.Distance(startPosition, targetPosition);
            float angle = EvaluateAngleFromDistance(distance);

            if (angle > _minAngle)
                angle = _minAngle;

            return angle;
        }
    }

    private float EvaluateAngleFromDistance(float distance)
    {
        return 6.66f * distance - 86.66f;
    }
}