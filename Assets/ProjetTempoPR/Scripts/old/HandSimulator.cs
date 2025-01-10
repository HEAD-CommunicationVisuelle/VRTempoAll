using UnityEngine;

namespace TempoPR
{

    public class HandSimulator : MonoBehaviour
    {
        // trigger detection of the object
        void OnTriggerEnter(Collider other)
        {
            Debug.Log("OnTriggerEnter");

            // Verify that the object is a sound player
            if (other.gameObject.GetComponent<PlaySound>() != null)
            {
                // Play the sound
                other.gameObject.GetComponent<PlaySound>().OnPointerClick(null);
            }
        }
    }
}