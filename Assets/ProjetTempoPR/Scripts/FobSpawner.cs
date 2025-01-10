using System.Linq;
using UnityEngine;

namespace TempoPR
{
    public class FobSpawner : MonoBehaviour
    {
        public GameObject[] fobPrefabs;
        public float spawnInitialDelay = 2f;
        public float spawnDelay = 2f; // fobs every 2 second
        public float initialSpeed = 1f;
        public int fobCount = 20;
        public float horizontalSpread = 1f;
        public float verticalSpread = 1f;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            Spawn();
        }

        void Spawn()
        {

            // spawn fobs along the spawner's z axis
            for (int i = 0; i < fobCount; i++)
            {

                float distance = initialSpeed * spawnInitialDelay + i * initialSpeed * spawnDelay;
                Vector3 position = transform.position + transform.forward * distance;

                // Instantiate a new Fob at the position of the spawner
                GameObject fob = Instantiate(fobPrefabs[Random.Range(0, fobPrefabs.Count())], position, Quaternion.identity);

                // Look at the spawner
                fob.transform.LookAt(transform);

                // Add a random offset to the x and y axis
                fob.transform.position += new Vector3(Random.Range(-horizontalSpread / 2, horizontalSpread / 2), Random.Range(-verticalSpread / 2, verticalSpread / 2), 0);

                // Set the speed of the fob
                fob.GetComponent<Fob>().speed = initialSpeed;
            }

        }
    }
}