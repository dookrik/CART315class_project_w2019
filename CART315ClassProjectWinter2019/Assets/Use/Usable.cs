using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Usable : MonoBehaviour
{
    /**
     * How far away can an object be and
     * still get used?
     */
    public float maxDistance = 2.0f;
    
    /**
     * These can be set in the Unity editor and will be
     * optionally triggered by the use action
     */
    public ParticleSystem specialEffect;
    public AudioSource sound;

    /**
     * This optional event can be set in the editor
     * to call any function from any script after this
     * item has been used
     */
    public UnityEvent doAfterBeingUsed;


    /**
     * Use this object on whatever is in front of the
     * character
     */
    public void Use(bool shouldDestroyAfterUse = false)
    {
        //Get the object in front of this player
        //Call Use(useTarget, shouldDestroyAfterUse)
    }

    /**
     * Use this object on a specific target
     */
    public void Use(GameObject target, bool shouldDestroyAfterUse = false)
    {
        UseTarget useTarget = target.GetComponent<UseTarget>();
        useTarget.Use();
        //Trigger the particles and sound
        //If shouldDestroyAfterUse is true, then destroy this object
        //Finally, do whatever after used
        if (doAfterBeingUsed != null)
        {
            doAfterBeingUsed.Invoke();
        }
    }
    
}
