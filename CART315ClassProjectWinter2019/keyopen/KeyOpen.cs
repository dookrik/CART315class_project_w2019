//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class KeyOpen : MonoBehaviour
//{
//    // Start is called before the first frame update
//    GameObject  usable, door,key;
//    void Start()
//    {
//        usable = GameObject.Find("Usable");
//        door = GameObject.Find("door");
//        key = GameObject.Find("key");
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (key!=null)
//        {
//            usable.GetComponent<Usable>().Use(door, false);
//        }
       
//    }

//   public void OnItemUsed() {

//        door.transform.Rotate(0,90,0);
//        Debug.Log("onitemused");
   
//   }
//}
