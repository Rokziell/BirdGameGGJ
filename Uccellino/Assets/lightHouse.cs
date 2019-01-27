using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightHouse : MonoBehaviour
{
    Animator animator; 

    // Update is called once per frame
    void Update()
    {
      animator = GetComponent<Animator>(); 
    }

 private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TRIGGER ENTER!"); 
        if(animator){
            animator.SetTrigger("show");
        }
    }

     private void OnTriggerExit(Collider other)
    {
        Debug.Log("TRIGGER OUT!"); 
       if(animator){
           animator.SetTrigger("hide"); 
       }
    }

}
