using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    [SerializeField]
    public float speed, maxSpeed, minSpeed, acceleration, jumpSpeed, slowSpeed;

    public bool grounded = true; 

    Vector3 forward, rigth;
    Rigidbody rigid;

    public int count = 0;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        speed = 0f;
        maxSpeed = 7f;
        minSpeed = 0f;
        acceleration = 0.2f;
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        rigth = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }

    void Update()
    {
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                Move();
            }

            if (Input.GetButtonUp("Horizontal") || Input.GetButtonUp("Vertical"))
            {
                Decelerate();
            }

            if (Input.GetButtonDown("Jump") && transform.position.y < 0.6)
            {
                grounded = false; 
                rigid.AddForce(Vector3.up * jumpSpeed * 100);
            }
    }

    void Move()
    {

        if (speed <= maxSpeed)
        {
            speed += acceleration;
        }

        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 rigthMovement = rigth * speed * Time.deltaTime * Input.GetAxisRaw("Horizontal");
        Vector3 upMovement = forward * speed * Time.deltaTime * Input.GetAxisRaw("Vertical");

        
        Vector3 heading = Vector3.Normalize(rigthMovement + upMovement);

        //transform.forward = heading; //rotation happens
        transform.position += rigthMovement; // movement happens
        transform.position += upMovement; // movement happens
    }

    void Decelerate()
    {
        while (speed >= minSpeed)
        {
            speed -= acceleration;
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                break;
            }
        }
        speed = Mathf.Clamp(speed, 0f, maxSpeed);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Flower")
        {
            if (Input.GetKeyDown("return"))
            {

                other.gameObject.SetActive(false);
                count++;
                maxSpeed -= slowSpeed;
            }
        }

        if(other.gameObject.CompareTag("floor") && transform.position.y < 0.5){
            grounded = true; 
        }
    }
}
