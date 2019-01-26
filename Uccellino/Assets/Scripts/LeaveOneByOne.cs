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
            //characterVariable.slotAmount[characterVariable.currentSlot].DetachChildren();
            Debug.Log("Solte");

            /*
            Debug.Log(characterVariable.count);
            for (int i = characterVariable.currentSlot - 1; i >= 0; i--)
            {
                Debug.Log(i);

                Destroy(characterVariable.slotAmount[i].GetChild(0).gameObject);
                characterVariable.maxSpeed += characterVariable.slowSpeed;
                characterVariable.jumpSpeed++;
            }*/
            characterVariable.currentSlot = 0;
            characterVariable.count = 0;
            Debug.Log(characterVariable.count);
        }            
    }

}
