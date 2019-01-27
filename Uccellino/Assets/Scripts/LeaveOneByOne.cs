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
            var flowerInGround = Instantiate(characterVariable.slots[characterVariable.currentSlot], characterVariable.transform);
            Debug.Log("Solte");
            characterVariable.currentSlot = 0;
            flowerInGround.gameObject.SetActive(true);
        }            
    }

}
