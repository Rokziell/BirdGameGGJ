using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class no_opacity : MonoBehaviour
{
    public SpriteRenderer render; 
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>(); 
        
    }

    // Update is called once per frame
    void Update()
    {
        render.color = new Vector4(1,1,1,.01f*Time.deltaTime); 
    }
}
