using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class startGame : MonoBehaviour
{
    Animator animator; 
    public void Start(){
        animator = GetComponent<Animator>(); 
        LeaveFlowersInHouse.gameOverVariable += EndGame; 
    }
    // Start is called before the first frame update
    public void StartGame(){
        var player = FindObjectOfType<PlayerController>();
        player.CINEMATIC = false; 
    }

    public void EndGame(){
        animator.SetTrigger("win"); 
    }

    public void GoToCredits(){
        var cortina = FindObjectOfType<Cortina>();
        cortina.On(); 
        Invoke("LoadCredits", 3f); 
    }

    void LoadCredits(){
        SceneManager.LoadScene(2); 
    }
}
