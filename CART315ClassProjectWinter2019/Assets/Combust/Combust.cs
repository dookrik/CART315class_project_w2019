// Combustion on mouse click -- change event if needed
// Fire effect used from Cosyio at www.youtube.com/watch?v=JTGv_maOyHk

// INSTRUCTIONS:
// - Drop script onto combustible object 
// - Drop "Combustion" prefab in "Particles" section of the script

// This script inherits behaviour from Break script and all Break functions and variables (except private) are visible to it 


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combust : Break
{

    public ParticleSystem particles; // Reference to particle system
    //public Break burn;

    //void Expire() 
    //{
    //    burn.explode();
    //}

    private void OnMouseDown()
    {
       
        Vector3 combustionPos = transform.position;

        GameObject particle = Instantiate(particles.gameObject);
        particle.transform.position = transform.position;
        Destroy(particle, 6);

        Invoke("explode", 5);
    }
 }
