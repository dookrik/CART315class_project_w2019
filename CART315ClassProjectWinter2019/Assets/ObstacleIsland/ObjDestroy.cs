using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
     StartCoroutine(CountDown());
    }

    // Update is called once per frame
    void Update()
    {

        //Destroy(this.gameObject);
    }

//        private void OnCollisionEnter(Collision collider)
//    {
////               if(collider.gameObject.tag == "Shield") {
//            Destroy(this.gameObject);
//              // }
//     }

    private IEnumerator CountDown() {

        yield return new WaitForSeconds(2.0f);
        Destroy(this.gameObject);
    }
}
