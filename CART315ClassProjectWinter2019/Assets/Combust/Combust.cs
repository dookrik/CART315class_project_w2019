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
    public float temperature;

    public ParticleSystem particles; // Reference to particle system

    public void burn()
    {
        Vector3 combustionPos = transform.position;

        GameObject particle = Instantiate(particles.gameObject);
        particle.transform.position = transform.position;

        Destroy(particle, 6);

        Invoke("explode", 5);

        temperature += 10;

        if(temperature > 5) 
        {
            gameObject.tag = "Burning";
        }
       
 
    }

    private void OnMouseDown()
    {
        burn();
    }

   
    public void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Burning")) 
        {

            this.temperature += 10;
            burn();
        }

    }



}
