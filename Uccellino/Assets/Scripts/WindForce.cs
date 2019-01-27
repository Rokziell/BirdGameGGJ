using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindForce : MonoBehaviour
{

    public GameObject windRightAnimation; 
    public GameObject windLeftAnimation; 


    private float randomTimeBeteweenWind, windX, windZ;
    public float minTime, maxTime, windForceNumber;
    public float minWindForce, maxWindForce;

    private bool isReadyToStart, isPreparing, isHitting;

    PlayerController playerController;

    public Rigidbody playerRigid;

    // Start is called before the first frame update
    void Start()
    {
        playerController = playerRigid.gameObject.GetComponent<PlayerController>(); 
        randomTimeBeteweenWind = Random.Range(minTime, maxTime);
        
        windForceNumber = Random.Range(minWindForce, maxWindForce);
        isReadyToStart = true;
        InvokeRepeating("WIND", 0f, 4f); 
    }

    // Update is called once per frame
    void Update()
    {
    }
    void  WIND(){
        StartCoroutine(SpawnWind());
    }
    IEnumerator SpawnWind()
    {
        if(!playerController.CINEMATIC){
        windX = Random.Range(0, 3) - 1f;
        windZ = Random.Range(0, 3) - 1f;
        Transform t = playerRigid.transform; 
        if(windX>0){
           GameObject o = Instantiate(windLeftAnimation, new Vector3(t.position.x+6, t.position.y+17, t.position.z-18), Quaternion.identity);
           yield return new WaitForSeconds(0.70f);
           Destroy(o); 
        }else{
          var o = Instantiate(windRightAnimation, new Vector3(t.position.x+6, t.position.y+17, t.position.z-18), Quaternion.identity);
          yield return new WaitForSeconds(0.70f);
          Destroy(o);
        }

        yield return new WaitForSeconds(0.70f);        
        //Aqui va la animacion del viento antes del hit
       

        

        playerRigid.AddForce(new Vector3(windX, 1.5f, windZ) * 40 * windForceNumber);
        yield return new WaitForSeconds(0.20f); 


        //Aqui animacion del hit
        playerRigid.AddForce(new Vector3(windX, 0, windZ) * 80 * windForceNumber);
        yield return new WaitForSeconds(randomTimeBeteweenWind);

        }
    }
}
