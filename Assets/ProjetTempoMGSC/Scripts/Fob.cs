using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace TempoMGSC
{

    public class Fob : MonoBehaviour, IPointerClickHandler
    {
        public static UnityEvent onFinished = new();

        public float speed = 1f;

        //Count the number of Fobs instances
        static int count = 0;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            // add 1 to the count
            count++;
        }

        // OnDestroy is called once per frame
        void OnDestroy()
        {
            //remove 1 from the count
            count--;

            //if there are no more Fob instances
            if (count == 0)
            {
                Debug.Log("All Fobs are destroyed");
                // call the onFinished event
                onFinished.Invoke();
            }
        }

        // Update is called once per frame
        void Update()
        {
            // Move the object on a z axis
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("OnPointerClick");
            
            //if the distance between the object and the camera is less than 1.5
            if (Vector3.Distance(transform.position, Camera.main.transform.position) < 1f)
            {
                Catch();
            }
        }

        //This function is called when the object is clicked or touched
        public void Catch()
        {
            Debug.Log("Catch");

            //destroy the object
            Destroy(gameObject);
        }
        // Detect trigger collision
        void OnTriggerEnter(Collider other)
        {
            Debug.Log("OnTriggerEnter with " + other.gameObject.name);

            Destroy(gameObject);
        }

    }
}