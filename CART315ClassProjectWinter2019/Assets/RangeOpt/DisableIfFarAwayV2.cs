using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableIfFarAwayV2 : MonoBehaviour
{
    private GameObject itemActivatorObject;
    private ItemActivatorV2 activationScript;
    public float distanceToDisable = 10;

    // --------------------------------------------------

    void Start()
    {
        itemActivatorObject = GameObject.Find("ItemActivatorObject");
        activationScript = itemActivatorObject.GetComponent<ItemActivatorV2>();

        StartCoroutine("AddToList");
    }

    IEnumerator AddToList()
    {
        yield return new WaitForSeconds(0.01f);
       // Debug.Log(this.gameObject);

        activationScript.addList.Add(new ActivatorItem { item = this.gameObject });
    }
}

//HOW TO USE 
//This script must be placed on every object in the game 
//The input field allows you to choose the max distance you want to put for each object 

//Credit goes to https://www.youtube.com/watch?v=tAbEvzZVz5E&feature=youtu.be as we used his script as the base