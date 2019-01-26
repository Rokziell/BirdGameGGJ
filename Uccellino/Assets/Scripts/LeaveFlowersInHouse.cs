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
            characterVariable.count = 0;
            Debug.Log(characterVariable.count);
        }
    }
}
