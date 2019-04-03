using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLauncher : MonoBehaviour {

    public ParticleSystem particleLauncher;
    public ParticleSystem splatterParticles;
    public Gradient particleColorGradient;
    public ParticleDecalPool splatDecalPool;

    private Watergun parent;

    List<ParticleCollisionEvent> collisionEvents;

    private bool isShooting = false;

    void Start ()
    {
        parent = GetComponentInParent<Watergun>();
        collisionEvents = new List<ParticleCollisionEvent> ();
    }

    void OnParticleCollision(GameObject other)
    {
        ParticlePhysicsExtensions.GetCollisionEvents (particleLauncher, other, collisionEvents);

        for (int i = 0; i < collisionEvents.Count; i++) 
        {
            splatDecalPool.ParticleHit (collisionEvents [i], particleColorGradient);
            EmitAtLocation (collisionEvents[i]);
        }

        parent.Collision(other);
    }

    void EmitAtLocation(ParticleCollisionEvent particleCollisionEvent)
    {
        splatterParticles.transform.position = particleCollisionEvent.intersection;
        splatterParticles.transform.rotation = Quaternion.LookRotation (particleCollisionEvent.normal);
        ParticleSystem.MainModule psMain = splatterParticles.main;
        psMain.startColor = particleColorGradient.Evaluate (Random.Range (0f, 1f));

        splatterParticles.Emit (1);
    }
        
    void Update () 
    {
        if (isShooting) 
        {
            ParticleSystem.MainModule psMain = particleLauncher.main;
            psMain.startColor = particleColorGradient.Evaluate (Random.Range (0f, 1f));
            particleLauncher.Emit (1);
        }

    }

    public void SetShooting(bool shooting)
    {
        isShooting = shooting;
    }
}