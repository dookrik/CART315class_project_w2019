using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableIfFarAway : MonoBehaviour
{
    private GameObject itemActivatorObject;
    private itemActivator activationScript;

    // Start is called before the first frame update
    void Start()
    {
        itemActivatorObject = GameObject.Find("itemActivatorObject");
        activationScript = itemActivatorObject.GetComponent<itemActivator>();
        StartCoroutine("AddToList");
    }

    IEnumerator AddToList()
    {
        yield return new WaitForSeconds(.01f);
        activationScript.activatorItems.Add(new ActivatorItem { item = this.gameObject, itemPos = transform.position });

    }
}
