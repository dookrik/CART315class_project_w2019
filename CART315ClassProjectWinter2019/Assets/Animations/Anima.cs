using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anima : MonoBehaviour
{

    public Animator animator;
    float InputX;
    float InputY;
    // Start is called before the first frame update
    void Start()
    {

        animator = this.gameObject.GetComponent<Animator>();

        
    }

    // Update is called once per frame
    void Update()
    {
        InputY = Input.GetAxis("Vertical");
        InputX = Input.GetAxis ("Horzontal")
        animator.SetFloat("InputY", InputY);
        animator,SetFloat("InputX", InputX);
        animator.SetFloat ("Speed", Speed)
    }
}
