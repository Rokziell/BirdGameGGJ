using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedScript : MonoBehaviour
{
    PlayerController characterVariable;

    // Start is called before the first frame update
    void Start()
    {
        characterVariable = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FinishedAnimation()
    {
        characterVariable.isReadyToPick = true;   
    }

}
