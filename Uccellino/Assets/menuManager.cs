using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class menuManager : MonoBehaviour
{
    Transform btns; 
    Image image; 
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>(); 
        btns = transform.GetChild(0); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 0){
            image.enabled = true; 
            btns.gameObject.SetActive(true); 
        }
        else{
             image.enabled = false; 
             btns.gameObject.SetActive(false);
        }
    }
}
