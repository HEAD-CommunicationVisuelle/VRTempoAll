using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Fob : MonoBehaviour, IPointerClickHandler
{

    public static UnityEvent onFinished = new();
    public float speed = 1f;

    //count the number of fobs instances
    static int count = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //add 1 to the count
        count++;
    }

    // Ondestroy is called when the object is destroyed
    void OnDestroy()
    {
        //remove 1 from the count
        count--;

        if (count == 0)
        {
            Debug.Log("All fobs are destroyed");
            onFinished.Invoke();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //move objects in z axis
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

    }

    public void OnPointerClick(PointerEventData eventData)
    {

        Catch();
    }

//function called on object touch
    public void Catch()
    {
        Debug.Log("Catch");

        //destroy object
        Destroy(gameObject);
    }

    //detect trigger collision
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerWidth " + other.gameObject.name);
        {
            //destroy object
            Destroy(gameObject);
        }
    }

}
