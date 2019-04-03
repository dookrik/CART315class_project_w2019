using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Watergun : MonoBehaviour
{
    public List<UnityEvent> onWaterCollided;
    private ParticleLauncher particleLauncher;
    
    void Awake()
    {
        onWaterCollided = new List<UnityEvent>();
        particleLauncher = GetComponentInChildren<ParticleLauncher>();
    }

    public void Collision(GameObject gameObject)
    {
        foreach (UnityEvent unityEvent in onWaterCollided)
        {
            unityEvent.Invoke();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            particleLauncher.SetShooting(true);
        }

        if (Input.GetKeyUp(KeyCode.J))
        {
            particleLauncher.SetShooting(false);
        }
        
        transform.Rotate(Vector3.right, Mathf.Sin(Time.deltaTime * 100));
    }
}
