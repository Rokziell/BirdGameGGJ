using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arbolZmanager : MonoBehaviour
{

    public bool debug=false; 
    SpriteRenderer sprite;
    Transform player;  
    BoxCollider col; 

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        col = GetComponent<BoxCollider>(); 
        player = Transform.FindObjectOfType<PlayerController>().transform;         
    }

    // Update is called once per frame
    void Update()
    {if(col){
     Vector3 colliderCenter = transform.TransformPoint(col.center);
        if(colliderCenter.z < player.position.z){
            sprite.sortingOrder = 1000;
        }else{
            sprite.sortingOrder = 7;
        }
        if(debug){
            Debug.Log("sorting:");
            Debug.Log(sprite.sortingOrder); 
        }
    }

    }
}
