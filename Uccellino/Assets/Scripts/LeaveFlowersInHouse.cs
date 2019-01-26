using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveFlowersInHouse : MonoBehaviour
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
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "House")
        {
            Debug.Log(characterVariable.count);
            for (int i = characterVariable.currentSlot -1; i >= 0; i--)
            {
                Debug.Log(i);
                characterVariable.slots[i].sprite = null; 
                characterVariable.maxSpeed += characterVariable.slowSpeed;
                characterVariable.jumpSpeed++;
            }
            characterVariable.currentSlot = 0;
            characterVariable.count = 0;
            Debug.Log(characterVariable.count);
        }
    }
}
