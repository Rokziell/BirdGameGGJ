using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveFlowersInHouse : MonoBehaviour
{
    PlayerController characterVariable;
    public int maxFlowersInHouse;
    private int flowersInTheHouse;


    // Start is called before the first frame update
    void Start()
    {
        characterVariable = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    delegate void GameOVer()

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "House")
        {
            for (int i = characterVariable.currentSlot -1; i >= 0; i--)
            {
                Destroy(characterVariable.slotAmount[i].GetChild(0).gameObject);
                characterVariable.maxSpeed += characterVariable.slowSpeed;
                characterVariable.jumpSpeed++;
                flowersInTheHouse++;
            }
            characterVariable.currentSlot = 0;
            if(flowersInTheHouse >= maxFlowersInHouse)
            {
                //GAME OVER
            }
        }
    }
}
