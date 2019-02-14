using UnityEngine;

public class Projectile
{
    public const float GravityAcceleration = 9.8f;
    
    public static Vector3 GetProjectileVelocity(float initialVelocity, float distance, Vector3 up, Vector3 forward)
    {
        float g = Vector3.Magnitude(Physics.gravity * GravityAcceleration);
        float theta = 0.5f * Mathf.Asin((g * distance) / (initialVelocity * initialVelocity));

        Vector3 Vx = (initialVelocity * Mathf.Cos(theta)) * forward;
        Vector3 Vy = (initialVelocity * Mathf.Sin(theta)) * up;

        return Vx + Vy;
    }

}
