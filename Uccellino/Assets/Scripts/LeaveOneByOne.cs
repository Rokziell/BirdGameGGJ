using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveOneByOne : MonoBehaviour
{

    PlayerController characterVariable;

    // Start is called before the first frame update
    void Start()
    {
        characterVariable = GetComponent<PlayerController>();        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Fire2") != 0){
            characterVariable.slotAmount[characterVariable.currentSlot].DetachChildren();
            Debug.Log("Solte");
            characterVariable.currentSlot = 0;
        }            
    }

}
