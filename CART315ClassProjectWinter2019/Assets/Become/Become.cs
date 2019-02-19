using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Become : MonoBehaviour
{
    private Camera fpsCam;
    RaycastHit hit;
    private float clickRange = 100f;
    private float t = 0.0f;

    //sounds
    private AudioClip swapSound;
    private AudioSource audioSource;

    void Start()
    {
        fpsCam = GetComponent<Camera>();
        fpsCam.fieldOfView = 60;

        //setting the audio sound component
        setAudioSource();
    }
    //we want to update every frame
    void Update()
    {
        //if left click
        if (Input.GetMouseButtonDown(0))
        {
            //create a ray that is between the camera position and the positoin of the object the mouse clicked on
            Ray rayEnd = fpsCam.ScreenPointToRay(Input.mousePosition);

            //if the mouse clicks on the gameobject and that gameobject has a CharacterController as a component, meaning that object is a player
            if (Physics.Raycast(rayEnd, out hit, clickRange) && hit.collider.gameObject.GetComponentInParent<CharacterController>() != null)
            {
                //setting the audio source component to the new gameobject (player)
                setAudioSource();

                //add a delay for the camera-switch animation
                StartCoroutine("SwitchCameraDelay", 0.7f);

                //playing the sound effect
                PlaySoundFx();

            }
        }
        //turn the camera towards the clicked object and make sure it's a player
        if (hit.collider != null && hit.collider.gameObject.GetComponentInParent<CharacterController>() != null)
        {
            Vector3 direction = hit.collider.gameObject.transform.position - transform.position;
            Quaternion endRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, endRotation, 20f * Time.deltaTime);
            fpsCam.fieldOfView = Mathf.Lerp(60, 1, t);
        }
        t += 0.7f * Time.deltaTime;
    }

    IEnumerator SwitchCameraDelay(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        //code executes after the waitTime is elapsed 
        SwitchCameras();
    }
   

    private void SwitchCameras()
    {
        //instantiate a new camera at the position of the object that was clicked on
        Become clickedObject = Instantiate(this, hit.collider.gameObject.transform.position, Quaternion.identity);
        clickedObject.gameObject.name = "Camera_Become";

        //make the camera a chid of the clicked game object and center its position relative to the player
        clickedObject.transform.SetParent(hit.collider.gameObject.transform);
        clickedObject.transform.localRotation = Quaternion.Euler(0, 0, 0);

       // hit.collider.gameObject.GetComponentInChildren<Camera>().fieldOfView = Mathf.Lerp(20, 60, t);


        //enable and disable the LocomotionUserControl - enable on one player at a time
        if (hit.collider.gameObject.GetComponentInParent<LocomotionUserControl>() != null)
        {
            GetComponentInParent<LocomotionUserControl>().enabled = false;
            hit.collider.gameObject.GetComponentInParent<LocomotionUserControl>().enabled = true;
        }

        //Destroy the old camera.
        Destroy(gameObject);
    }

    private void setAudioSource()
    {

        //load the sound clip from the Resources folder in the asset
        swapSound = Resources.Load<AudioClip>("Sounds/Swap_sound");

        //checks for empty audio source component
        if (GetComponent<AudioSource>() == null)
        {
            //add audio component
            audioSource = gameObject.AddComponent<AudioSource>() as AudioSource;
        }
        else
        {
            //get audio component
            audioSource = GetComponent<AudioSource>();
        }
    }

    private void PlaySoundFx()
    {
        //play the sound fx        
        audioSource.PlayOneShot(swapSound, 0.8f);
    }

}
