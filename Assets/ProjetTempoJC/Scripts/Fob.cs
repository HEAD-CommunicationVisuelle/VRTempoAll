
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace TempoJC
{

    public class Fob : MonoBehaviour, IPointerClickHandler
    {

        public static UnityEvent onFinsihed = new();
        public float speed = 1f;

        // Count the number of Fob instances
        static int count = 0;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            // add 1 to the count
            count++;
        }

        // OnDestroy is called when the object is clicked or touched
        void OnDestroy()
        {

            // remove 1 frome the count
            count--;

            // if there are no more Fob instances
            if (count == 0)
            {

                //Debug.Log("All Fobs are destroyed");

                //call the onFinished event
                onFinsihed.Invoke();
            }
        }


        // Update is called once per frame
        void Update()
        {
            // Turbo speed if T key pressed
            float turbo = Keyboard.current.tKey.isPressed ? 10 : 1;

            // Move the object on z axis
            transform.Translate(Vector3.forward * speed * turbo * Time.deltaTime);
        }
        public void OnPointerClick(PointerEventData eventData)

        {
            // if the distance between the object and the camera is less than 1.5
            if (Vector3.Distance(transform.position, Camera.main.transform.position) < 1.5f)
                Catch();
        }

        // This function is called when the object is clicked or touched
        public void Catch()
        {
            Debug.Log("Catch");

            // destroy the object
            Destroy(gameObject);

        }

        // Detect trigger collision

        void OnTriggerEnter(Collider other)
        {
            Debug.Log("OnTriggerEnter with" + other.gameObject.name);
            Destroy(gameObject);
        }

    }
}
