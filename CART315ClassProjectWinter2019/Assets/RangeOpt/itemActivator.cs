using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class itemActivator : MonoBehaviour
{
    //DO NOT USE THIS SCRIPT

    [SerializeField]
    private int distanceFromPlayer;

    private GameObject player;

    //list; like a raise but flexible, can add and remove things
    //adds and removes items easier, better than array
    //activatoritem is a class of our own
    public List<ActivatorItem> activatorItems;
    // Start is called before the first frame update
    void Start()
    {
        //find the player object we called
        player = GameObject.Find("Player");
        //initialize list
        activatorItems = new List<ActivatorItem>();
        StartCoroutine("CheckActivation");
    }

 IEnumerator CheckActivation()
    {
        List<ActivatorItem> removeList = new List<ActivatorItem>();

        if (activatorItems.Count > 0)
        {
            foreach (ActivatorItem item in activatorItems)
            {
                //Getting the item in the list and checking our value we created
                //will store a vector3, itll have the gameobject and its position 
                if (Vector3.Distance(player.transform.position, item.itemPos) > distanceFromPlayer)
                {
                    //if an item has been destroyed since the last time we used it
                    //list cant remove items, so we add it to a second list and remove it there
                    if (item.item == null)
                    {
                        removeList.Add(item);
                    }
                    else
                    {
                        item.item.SetActive(false);
                    }
                }
                   else
                {
                    if (item.item == null)
                    {
                        removeList.Add(item);
                    }
                    else
                    {
                        item.item.SetActive(true);
                    }
                }
            }
        }
        yield return new WaitForSeconds(.1f);

        if (removeList.Count > 0)
        {
            foreach (ActivatorItem item in removeList)
            {
                activatorItems.Remove(item);
            }
        }
        yield return new WaitForSeconds(0.1f);
        StartCoroutine("CheckActivation");
    }
}
//classes can have any info you want
//were creating a class which activates items
//will have game items and pause
public class ActivatorItem
{
    public GameObject item;
    public Vector3 itemPos;
}