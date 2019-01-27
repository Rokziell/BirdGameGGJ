using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveFlowersInHouse : MonoBehaviour
{
    PlayerController characterVariable;
    public HomeSpriteChanger homeChanger;
    public int maxFlowersInHouse;
    private int flowersInTheHouse, flowersForNextLevel, rangeToNextLevel;
    public float timeDelay;

    // Start is called before the first frame update
    void Start()
    {
        characterVariable = GetComponent<PlayerController>();
        timeDelay = 1.5f;
        flowersForNextLevel = 2;
        rangeToNextLevel = 2;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "House")
        {
            for (int i = characterVariable.currentSlot - 1; i >= 0; i--)
            {
                Debug.Log(i);
                characterVariable.slots[i].sprite = null;
                characterVariable.maxSpeed += characterVariable.slowSpeed;
                characterVariable.jumpSpeed++;
                flowersInTheHouse++;
            }
            
            characterVariable.currentSlot = 0;
            if (flowersInTheHouse >= maxFlowersInHouse)
            {
                homeChanger.currentHomeSprite++;
                homeChanger.spriteRenderer.sprite = homeChanger.homeSprites[homeChanger.currentHomeSprite];
                Debug.Log("GAME OVER!!!!");
                gameOverVariable();
            }
            CheckForLevelUpgrade();     
        }
    }
    void CheckForLevelUpgrade(){
        if(flowersInTheHouse >= flowersForNextLevel)
        {
            homeChanger.currentHomeSprite++;
            homeChanger.spriteRenderer.sprite = homeChanger.homeSprites[homeChanger.currentHomeSprite];
            flowersForNextLevel += rangeToNextLevel;
            Invoke("CheckForLevelUpgrade", timeDelay); 
        }
    }
    delegate void GameOver();
    GameOver gameOverVariable;
}
