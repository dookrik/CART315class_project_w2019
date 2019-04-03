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
//Place onto every object in the scene, manipulate the distance to what you feel
//The render distance should be.

//CREDIT TO: https://www.youtube.com/watch?v=tAbEvzZVz5E&feature=youtu.be for helping us with base code