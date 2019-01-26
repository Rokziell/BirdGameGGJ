using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaterController : MonoBehaviour
{
    [SerializeField]
    float speed, maxSpeed, minSpeed;

    Vector3 forward, rigth;

    void Start()
    {
        speed = 0f;
        maxSpeed = 20f;
        minSpeed = 0f;
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        rigth = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            Move();
        }
    }

    void Move()
    {
        if(speed <= maxSpeed)
        {
            speed += 0.5f;
        }
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 rigthMovement = rigth * speed * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 upMovement = forward * speed * Time.deltaTime * Input.GetAxis("Vertical");

        Vector3 heading = Vector3.Normalize(rigthMovement + upMovement);

        transform.forward = heading; //rotation happens
        transform.position += rigthMovement; // movement happens
        transform.position += upMovement; // movement happens
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Flower")
        {
            other.gameObject.SetActive(false);
        }
    }
}
