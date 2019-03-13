using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //game object array
    public GameObject[] spawnObject;
    //game object for the portal animation
    public GameObject portalAnimation;
    //animation enable flag
    public bool portalAnimationEnable = true;
    //audio clip for sound effect
    public AudioClip soundFx;
    //max spawner
    public int maxSpawn = 30;
    //current number of spawned
    private int currentSpawn = 0;
    //enable the spawner interval
    public bool spawnerIntervalEnable = true;
    //spawner interval by seconds
    public float spawnerInterval = 3f;
    //z force physic
    public float zForceThrust = 200;
    //volume amplitude | 1f is max volume it could have
    public float soundVolume = 1f;
    //manual button for spawner
    public string spawnerButton = "Fire1";
    //manual button for iterating the array object
    public string selectorButton = "Fire2";

    //array index indicator
    private int currentArrayIndex = 0;
    //audio source component. This component needs to be added on the object
    private AudioSource soundSource;
    //spawner timer
    private float spawnerTimer;
    //reference to the portalAnimation prefab
    private GameObject portal;
    //portalAnimation's duration
    private float portalAnimDur = 1f;
    //bool flag when to starting animating
    private bool startAnimPortal;



    // Start is called before the first frame update
    void Start()
    {
        //check if there is an audio source
        if (GetComponent<AudioSource>() == null)
        {
            soundSource = gameObject.AddComponent<AudioSource>() as AudioSource;
        }
        else
        {
            //initialize audiosource
            soundSource = GetComponent<AudioSource>();
        }


        //instantiating the portalAnimation
        portal = Instantiate(portalAnimation, transform.position, transform.rotation) as GameObject;
        portal.transform.localScale = new Vector3(1f, 1f, 1f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //invoke selectObject
        selectObject(selectorButton);

        //invoke spawner with interval param
        Spawn(spawnerInterval);

        //invoke spawner with spawnerButton param
        Spawn(spawnerButton);

        //invoke animation 
        Animation(portalAnimationEnable);

    }

    //primary spawn function without parameter
    public void Spawn()
    {
        if (currentSpawn <= maxSpawn)
        {
            //play the sound fx        
            soundSource.PlayOneShot(soundFx, soundVolume);

            //create a temporary object holder for prefab cloning
            GameObject tempObject = Instantiate(spawnObject[currentArrayIndex], transform.position, transform.rotation) as GameObject;
            //add relative force when the prefab is instantiated.
            tempObject.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, zForceThrust));

            currentSpawn++;
        }
        else
        {
            Debug.Log("Exceed maxSpawn: " + currentSpawn);
            //disable animation
            portalAnimationEnable = false;
            //disable interval
            spawnerIntervalEnable = false;
        }

    }

    //spawn function by interval
    public void Spawn(float interval)
    {

        if (spawnerIntervalEnable)
        {

            //add the deltaTime in the timer
            spawnerTimer += Time.fixedDeltaTime;


            //check if spawnerTimer exceeds the spawnerInterval
            if (spawnerTimer > interval)
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
        }
        else
        {

        }
    }

    //spawn function by button click
    public void Spawn(string button)
    {
        if (Input.GetButtonDown(button))
        {
            Debug.Log(button + " is pressed.");
            //invoke spawn function
            Spawn();
        }
    }

    //animation function
    public void Animation(bool animationEnable)
    {
        if (animationEnable)
        {
            //enable the display 
            portal.GetComponent<MeshRenderer>().enabled = true;

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
        else
        {
            //set the scale to the orginal
            portal.transform.localScale = new Vector3(1f, 1f, 1f);
            //disable the display 
            portal.GetComponent<MeshRenderer>().enabled = false;
        }

    }

    //selectObject selects which object to spawn
    public void selectObject(string selButton)
    {
        //if the button is pressed
        if (Input.GetButtonDown(selButton))
        {
            Debug.Log(selButton + " is pressed. " + currentArrayIndex);
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
    }
}
