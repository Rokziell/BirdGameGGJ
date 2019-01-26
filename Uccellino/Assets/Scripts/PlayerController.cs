using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    [SerializeField]
    float speed, minSpeed, acceleration;
    Renderer renderSeed;

    public  float maxSpeed, jumpSpeed, slowSpeed;

    public bool grounded = true;
    public bool picoteando = false;

    Vector3 forward, rigth;
    Rigidbody rigid;

    public Transform[] slotAmount;
    public GameObject flowerPrefab;
    internal int currentSlot;

    internal  Transform floorChild;

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

            if(Input.GetButtonDown("Fire1") && grounded){
                picoteando = true;
                Invoke("FinishPico", .75f);
            }

            if (Input.GetButtonDown("Fire2"))
            {
            LeaveOnePerTime();
            }
    }

    void Move()
    {
        if(picoteando) return;
        if (speed <= maxSpeed)
        {
            speed += acceleration;
        }

        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 rigthMovement = rigth * speed * Time.deltaTime * Input.GetAxisRaw("Horizontal");
        Vector3 upMovement = forward * speed * Time.deltaTime * Input.GetAxisRaw("Vertical");


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
            if (Input.GetButtonDown("Submit"))
            {
                Instantiate(flowerPrefab, slotAmount[currentSlot]);
                other.gameObject.SetActive(false);
                maxSpeed -= slowSpeed;
                jumpSpeed --;
                currentSlot++;
            }
        }

        if(other.gameObject.tag == "Seed")
        {
            if (Input.GetButtonDown("Submit"))
            {
                Debug.Log("Colisione con seed");
                renderSeed = other.gameObject.GetComponent<Renderer>();
                renderSeed.enabled = true;
                while (other.transform.position.y <= 0.5)
                {
                    other.transform.Translate(Vector3.up * 0.05f);
                }
                other.gameObject.tag = "Flower";
            }
        }

        if(other.gameObject.CompareTag("floor") && transform.position.y < 0.5){
            grounded = true;
        }
    }

    void FinishPico(){
        picoteando = false;
    }

    void LeaveOnePerTime()
    {
        floorChild = slotAmount[currentSlot - 1].GetChild(0).parent = null;
        maxSpeed += slowSpeed;
        jumpSpeed ++;
        currentSlot --;
        Debug.Log("SAco");
    }

}
