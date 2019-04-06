using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    /***
    SPAWNER SCRIPT INSTRUCTION
    1 - Attach the script to an empty gameobject. If you attach the script to a gameobject or prefab; make sure the collision component is disabled. The objects spawn inside the object.
    2 - Set a size (click on Spawn object to see it) for Spawn Object. This will create an array to hold the game objects or prefabs. 
    3 - Drag and drop the prefab(s) or gameobject(s) in the Spawn Objects Slot(s) in the inspector.
        note* If you put more than one game object or prefab; the script will randomly select one of them to spawn. 
        note* The game object or prefab needs a rigidbody.
    4 - Set the object scale for your game objects or prefabs
    5 - The particle effect is pre-added, and you can change it by dragging and dropping one in the inspector.
        note* the particle effect is being instantiated when object is spawned. It does not use the stop and play method. 
    6-  The sound effect is pre-added, and you can change it by dragging and dropping one in the inspector.
         note* Sound Volume controls the intensity of the sound. 1 = Max and 0 = muted
    7 - You can disable or enable the Spawner Interval Enable.
        note* disable this if you want manual control, and call the spawn() function in your own script to spawn a object.  
    8 - You can set the interval spawning time by second. Default interval time is set to 3 second.
    9 - You can change the z force thrust in the inspector.

    ***/
    //game object array
    public GameObject[] spawnObject;
    //scaler for the spawnObject
    public float objectScale = 1f;
    //max spawner
    public int maxSpawn = 10;
    //particle effect
    public ParticleSystem particleEffect;
    //animation enable flag
    public bool particleEffectEnable = true;
    //audio clip for sound effect
    public AudioClip soundEffect;
    //volume amplitude | 1f is max volume it could have
    public float soundVolume = 1f;
    //enable the spawner interval
    public bool spawnerIntervalEnable = true;
    //spawner interval by seconds
    public float spawnerInterval = 3f;
    //z force physic
    public float zForceThrust = 200;

    //saved instantiated object
    private GameObject[] savedObject;
    //counter for empty savedObject
    private int countEmpty = 0;
    //index of Spawned object
    private int currentSpawnedIndex = 0;
    //audio source component. This component needs to be added on the object
    private AudioSource soundSource;
    //spawner timer
    private float spawnerTimer;



    // Start is called before the first frame update
    void Start()
    {
        //check if there is an audio source
        if(GetComponent<AudioSource>() == null)
        {
            //add an AudioSource
            soundSource = gameObject.AddComponent<AudioSource>() as AudioSource;
        }
        else
        {
            //initialize audiosource
            soundSource = GetComponent<AudioSource>();
        }

        //declare the game object spawnedObject
        savedObject = new GameObject[maxSpawn];

        //check if the particle effect is null 
        if(particleEffect == null)
        {
            //set a particle effect from the resources folder
            particleEffect = Resources.Load<ParticleSystem>("ParticleSystem/PuffSmoke");
        }

        if(soundEffect == null)
        {
            soundEffect = Resources.Load<AudioClip>("Sounds/Explosion_spawn");
        }


    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //invoke spawner with interval param
        SpawnByInterval();

        Debug.Log(GetRandomIndex());

    }


    //function that instantiates the selected gameObject
    private void InstantiateGameObject()
    {

        int randomIndex = GetRandomIndex();

        //get an empty index
        currentSpawnedIndex = checkIndex();

        //modify the scale of the gameobject
        spawnObject[randomIndex].transform.localScale = new Vector3(objectScale, objectScale, objectScale);

        //***change the position of spawning outside the model (gameobject)

        //create a temporary object holder for prefab cloning
        GameObject obj = Instantiate(spawnObject[randomIndex], transform.position, transform.rotation) as GameObject;
        //add relative force when the prefab is instantiated.
        obj.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, zForceThrust));

        //add the object
        savedObject[currentSpawnedIndex] = obj;
    }

    //function that checks a current empty gameobject index
    private int checkIndex()
    {
        //place holder for the index
        int index = 0;

        //loops to find an empty index
        for (int i = 0; i < savedObject.Length; i++)
        {
            //check if empty
            if(savedObject[i] == null)
            {
                //save the index
                index = i;
                //break out of the loop
                break;
            }
        }

        //return the index
        return index;
    }

    //function that checks the number of spawned game objects
    private int checkSpawnedNum()
    {
        //place holder for the number of spawned object
        int numSpawned = 0;

        //loops to check
        for (int i = 0; i < savedObject.Length;i++)
        {
            //check for spawned gameobject
            if (savedObject[i] != null)
            {
                //increment the counter
                numSpawned++;
            }
        }

        //return the value
        return numSpawned;
    }


    //function that instantiates the particle system
    public void PlayParticleEffect()
    {
        //if the particle effect button is enable
        if (particleEffectEnable)
        {
            //instantiate the particle effect
            ParticleSystem effect = Instantiate(particleEffect, transform.position, transform.rotation);
        }
        
    }

    //primary spawn function without parameter
    public void Spawn()
    {
        //check if the 
        if (checkSpawnedNum() < maxSpawn)
        {
            //play the sound fx        
            soundSource.PlayOneShot(soundEffect, soundVolume);

            //instantiate the particle effect
            PlayParticleEffect();

            //create an object
            InstantiateGameObject();
        }
    }

    //spawn function by interval
    public void SpawnByInterval()
    {
        //check if the button is enable
        if (spawnerIntervalEnable)
        {

            //update spawnerTimer
            spawnerTimer += Time.fixedDeltaTime;


            //check if spawnerTimer exceeds the spawnerInterval
            if (spawnerTimer > spawnerInterval)
            {
                //invoke spawn function
                Spawn();

                //remove the interval in the timer
                spawnerTimer -= spawnerInterval;
            }
        }
        else
        {
          
        }
    }

    public int GetRandomIndex()
    {
        return Random.Range(0, spawnObject.Length);
    }

    public void ActionSpawn()
    {

    }
}
