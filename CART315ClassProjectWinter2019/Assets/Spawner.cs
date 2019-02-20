using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //game object array
    public GameObject[] spawnObject;
    //game object for the portal animation
    public GameObject portalAnimation;
    //audio clip for sound effect
    public AudioClip soundFx;

    //array index indicator
    private int currentArrayIndex = 0;
    //z force physic
    private float zForceValue = 200;
    //audio source component. This component needs to be added on the object
    private AudioSource soundSource;
    //volume amplitude
    private float soundVolume = 1f;
    //spawner interval by seconds
    private float spawnerInterval = 3f;
    //spawner timer
    private float spawnerTimer;
    //reference to the portalAnimation prefab
    private GameObject portal;
    //portalAnimation's duration
    private float portalAnimDur =1f;
    //bool flag when to starting animating
    private bool startAnimPortal;

  

    // Start is called before the first frame update
    void Start()
    {
        //check if there isn't a audioSource component
        if (GetComponent<AudioSource>() == null)
        {
            //add an audioSource component
            soundSource = gameObject.AddComponent<AudioSource>() as AudioSource;
        }
        else
        {
            //getting the audioSource Component
            soundSource = GetComponent<AudioSource>();
        }

        //instantiating the portalAnimation
        portal = Instantiate(portalAnimation, transform.position, transform.rotation) as GameObject;
        portal.transform.localScale = new Vector3(1f, 1f, 1f);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //add the deltaTime in the timer
        spawnerTimer += Time.fixedDeltaTime;

        //check if spawnerTimer exceeds the spawnerInterval
        if (spawnerTimer > spawnerInterval)
        {
            //invoke spawn function
            Spawn();

            //remove the interval in the timer
            spawnerTimer -= spawnerInterval;

            //setting the flag to true
            startAnimPortal = true;

            //set the scale to the orginal
            portal.transform.localScale = new Vector3(1f, 1f, 1f);

        }

        //reset the portalAnimation to original scale
        if (startAnimPortal)
        {
            
           //scaling down the object
            portal.transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
          

            //check if the animation duration is over
            if (spawnerTimer > portalAnimDur)
            {
                //setting the flag to false
                startAnimPortal = false;

            }

        }

     
    }

    //spawner function 
    void Spawn()
    {
        //play the sound fx        
        soundSource.PlayOneShot(soundFx, soundVolume);

        //create a temporary object holder for prefab cloning
        GameObject tempObject = Instantiate(spawnObject[currentArrayIndex], transform.position, transform.rotation) as GameObject;       
        //add relative force when the prefab is instantiated.
        tempObject.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0,0, zForceValue));

        //iterate the game object array
        if (currentArrayIndex < spawnObject.Length - 1)
        {
            currentArrayIndex++;
        }
        else
        {
            currentArrayIndex = 0;
        }

    }

    //selectObject selects which object to spawn
    public void selectObject(int index)
    {
        //check if the index is within the range
        if(index < spawnObject.Length - 1)
        {
            currentArrayIndex = index;
        }
        else
        {
            //console log error
            Debug.Log("Index selected is out of bound.");
        }
    }
}
