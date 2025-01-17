using UnityEngine;

namespace TempoJC
{

    public class RandomRotate : MonoBehaviour
    {
        Vector3 rotation;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            // random start oritentation rotation
            transform.Rotate(Random.Range(-180, 180), Random.Range(-180, 180), Random.Range(-180, 180));

            // random rotation direction
            rotation = new Vector3(Random.Range(-180, 180), Random.Range(-180, 180), Random.Range(-180, 180));

        }

        // Update is called once per frame
        void Update()
        {
            // rotate the object on the y axis
            transform.Rotate(rotation * Time.deltaTime);
        }
    }
}
