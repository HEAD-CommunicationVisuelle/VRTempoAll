using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Fob : MonoBehaviour, IPointerClickHandler
{

    public static UnityEvent onFinish = new();

    public float speed = 1f;

// Count the number of fob instances
    static int Count = 0;

   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // add 1 to the count
        Count++;
    }

    // OnDestroy is called when the object is destroyed
    void OnDestroy()
    {
        // remove 1 from the count
        Count--;

        // if the count is 0, it means that all fobs have been destroyed
        if (Count == 0)
        {
            onFinish.Invoke();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Move the object on z axis
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Vector3.Distance(transform.position, Camera.main.transform.position) < 1f)
        Catch();
    }


    // This function is called when the object is clicked or touched
    public void Catch (){
        Debug.Log("Catch");
        
        // Destroy the object
        Destroy(gameObject);
    }

    // detect trigger collision

    void OnTriggerEnter(Collider other) {
        Debug.Log("OnTriggerWith " + other.gameObject.name);

        Destroy(gameObject);
    }

}
