using System.Linq;
using UnityEngine;

public class FobSpawner : MonoBehaviour
{
    public GameObject[] fobPrefab;
    public float spawnInitialDelay = 2f;
    public float spawnDelay = 2f; //fobs every x (2) seconds
    public float initialSpeed = 1f;
    public int fobCount = 20;
    public float verticalSpread = 1f;
    public float horizontalSpread = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        //spawnx  fobs along the spawner's z axis
        for (int i = 0; i < fobCount; i++)
        {
            float distance = initialSpeed * spawnInitialDelay + i * initialSpeed * spawnDelay;
            Vector3 position = transform.position + transform.forward * distance; // new Vector3(0, 0, distance);

            //initiate a new fob at spawn position
            GameObject fob = Instantiate(fobPrefab[Random.Range(0, fobPrefab.Count())], position, Quaternion.identity);

            //look at the spawner
            fob.transform.LookAt(transform);

            //add some randomness to the position
            fob.transform.position += new Vector3(UnityEngine.Random.Range(-horizontalSpread/2, horizontalSpread/2), UnityEngine.Random.Range(-verticalSpread/2, verticalSpread/2), 0);
           
            //set the speed of the fob
            fob.GetComponent<Fob>().speed = initialSpeed;
        }

    }

}