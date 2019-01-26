using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    [SerializeField]
    float speed, minSpeed, acceleration;

    public  float maxSpeed, jumpSpeed, slowSpeed;

    Vector3 forward, rigth;
    Rigidbody rigid;


    public int count = 0;
    public Transform[] slotAmount;
    public GameObject flowerPrefab;
    internal int currentSlot;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        jumpSpeed = 3;
        slowSpeed = 1.5f;
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

        if (Input.anyKey)
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
                rigid.AddForce(Vector3.up * jumpSpeed * 100);
            }
        }
    }

    void Move()
    {

        if (speed <= maxSpeed)
        {
            speed += acceleration;
        }

        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 rigthMovement = rigth * speed * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 upMovement = forward * speed * Time.deltaTime * Input.GetAxis("Vertical");

        Vector3 heading = Vector3.Normalize(rigthMovement + upMovement);
        
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
                Instantiate(flowerPrefab, slotAmount[currentSlot]);
                other.gameObject.SetActive(false);
                count++;
                maxSpeed -= slowSpeed;
                jumpSpeed --;
                currentSlot++;
            }
        }
    }
}
