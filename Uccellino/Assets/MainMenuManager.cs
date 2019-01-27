using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuManager : MonoBehaviour
{
    Cortina cortina; 
    // Start is called before the first frame update
    void Start()
    {
        cortina = GetComponent<Cortina>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown){
            cortina.On(); 
            Invoke("LoadTheLevel", 3f); 
        }
    }

    void LoadTheLevel(){
        SceneManager.LoadScene(1);//ints and such also work.
    }
}
