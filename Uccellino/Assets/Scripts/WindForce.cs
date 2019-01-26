using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindForce : MonoBehaviour
{
    private float randomTimeBeteweenWind, windX, windZ;
    public float minTime, maxTime, windForceNumber;
    public int minWindForce, maxWindForce;

    private bool isReadyToStart, isPreparing, isHitting;

    public Rigidbody playerRigid;

    // Start is called before the first frame update
    void Start()
    {
        randomTimeBeteweenWind = Random.Range(minTime, maxTime);
        StartCoroutine(SpawnWind());
        windForceNumber = Random.Range(minWindForce, maxWindForce);
        isReadyToStart = true;
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator SpawnWind()
    {
        //Aqui va la animacion del viento antes del hit
        yield return new WaitForSeconds(0.70f);

        windX = Random.Range(0, 3) - 1f;
        windZ = Random.Range(0, 3) - 1f;

        playerRigid.AddForce(new Vector3(windX, 1.5f, windZ) * 40 * windForceNumber);
        yield return new WaitForSeconds(0.20f); 


        //Aqui animacion del hit
        playerRigid.AddForce(new Vector3(windX, 0, windZ) * 80 * windForceNumber);
        yield return new WaitForSeconds(randomTimeBeteweenWind);

        StartCoroutine(SpawnWind());
    }
}
