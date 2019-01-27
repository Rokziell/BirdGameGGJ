﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveFlowersInHouse : MonoBehaviour
{
    PlayerController characterVariable;
    public HomeSpriteChanger homeChanger;
    public int maxFlowersInHouse;
    private int flowersInTheHouse, flowersForNextLevel, rangeToNextLevel;
    private float timeDelay;
    

    // Start is called before the first frame update
    void Start()
    {
        characterVariable = GetComponent<PlayerController>();
        timeDelay = 0.5f;
        flowersForNextLevel = 2;
        rangeToNextLevel = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //delegate void GameOVer();

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "House")
        {
            for (int i = characterVariable.currentSlot -1; i >= 0; i--)
            {
                Debug.Log(i);
                characterVariable.slots[i].sprite = null; 
                characterVariable.maxSpeed += characterVariable.slowSpeed;
                characterVariable.jumpSpeed++;
                flowersInTheHouse++;
            }
            
            characterVariable.currentSlot = 0;
            if(flowersForNextLevel >= maxFlowersInHouse)
            {
                homeChanger.currentHomeSprite++;
                homeChanger.spriteRenderer.sprite = homeChanger.homeSprites[homeChanger.currentHomeSprite];
                Debug.Log("GAME OVER!!!!"); 
            }
            else
            {
                if (flowersInTheHouse >= flowersForNextLevel)
                {
                    homeChanger.currentHomeSprite++;
                    homeChanger.spriteRenderer.sprite = homeChanger.homeSprites[homeChanger.currentHomeSprite];
                    flowersForNextLevel += rangeToNextLevel;
                }
            }
        }
    }
}
