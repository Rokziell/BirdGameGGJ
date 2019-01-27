using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

[ExecuteInEditMode]
public class Cortina : MonoBehaviour {


	AudioSource audio;
    public Material effectMaterial;

    public bool RevealOnAwake = false; 

    public bool isMenu = true; 
    public bool on = true;
    [Range(0.01f,2f)]
    public float  speed  = 0.02f;
    private bool lastState; 

    [Range(0f ,1.1f)]
    public float currentPos = 1.1f;



    void Awake(){
		audio = GetComponent<AudioSource>();
        lastState = on;
        if(RevealOnAwake){
            currentPos = 1.1f; 
            on = false; 
        }
    }

    private void Start()
    {
        Invoke("Off", 1.5f); 
    }

    // Update is called once per frame
    void Update () {

        if(Input.GetKeyDown("r")){
            SceneManager.LoadScene(1); 
        }

        if (on)
        {
            currentPos += speed * Time.deltaTime; 
        }
        else
        {
            currentPos -= speed * 2 * Time.deltaTime;
        }
        currentPos = Mathf.Clamp(currentPos, 0, 1.1f); 
        effectMaterial.SetFloat("_Cutoff", currentPos);


        if(Input.GetButtonDown("Submit") && isMenu){
           if(on){
               ContinueGame(); 
           }else{
                PauseGame(); 
            }
        }
    }
    public void ContinueGame(){
        on = false; 
        Time.timeScale = 1; 
    }
    public void PauseGame(){
        Time.timeScale = 0; 
        on = true; 
        currentPos = .3f; 
    }

    public void GoToTitle(){
        Time.timeScale = 1; 
        SceneManager.LoadScene(0); 
    }

	public void PlayClip(){
        if(audio){
    		audio.Play(); 
        }
	}

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, effectMaterial);
    }



    public void On()
    {
        on = true;
        PlayClip();
    }

    public void Off()
    {
        on = false;
        PlayClip();
    }
}
