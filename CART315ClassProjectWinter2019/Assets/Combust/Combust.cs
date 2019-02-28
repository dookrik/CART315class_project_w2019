// Combustion on mouse click -- change event if needed
// Fire effect used from Cosyio at www.youtube.com/watch?v=JTGv_maOyHk

// INSTRUCTIONS:
// - Drop script onto combustible object 
// - Drop "Combustion" prefab in "Particles" section of the script


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combust : MonoBehaviour
{
    public ParticleSystem particles; // Reference to particle system


    private void OnMouseDown()
    {
       
        Vector3 combustionPos = transform.position;

        GameObject particle = Instantiate(particles.gameObject);
        particle.transform.position = transform.position;
        //Destroy(particle, 40);

    }
 }
