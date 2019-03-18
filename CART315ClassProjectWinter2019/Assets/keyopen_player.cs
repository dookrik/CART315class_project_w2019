<<<<<<< HEAD
﻿//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class keyopen_player : MonoBehaviour
//{
//    float speed = 10f;
//    // Start is called before the first frame update
//    void Start()
//    {
        
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0f, Input.GetAxisRaw("Vertical") * speed * Time.deltaTime);
//    }
//}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyopen_player : MonoBehaviour
{
    float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0f, Input.GetAxisRaw("Vertical") * speed * Time.deltaTime);
    }
}
>>>>>>> 324f42a4b241d2f49be57049f0efea018fe208d5
