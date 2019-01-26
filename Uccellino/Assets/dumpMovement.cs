using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dumpMovement : MonoBehaviour
{

    public float speed = 4f; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

  void Update()
    {
        transform.position = new Vector3(transform.position.x + speed*Time.deltaTime, transform.position.y, transform.position.z); 
        Debug.Log(transform.position);
    }
}
