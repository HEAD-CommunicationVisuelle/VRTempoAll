using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.Interaction.Toolkit;

namespace TempoPR
{
    public class PlaySound : MonoBehaviour, IPointerClickHandler
    {
        public float speed = 1.0f;
        public AudioClip clip;

        private static AudioSource audioSource;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            // point at camera
            //transform.LookAt(Camera.main.transform);

            // find the AudioSource component on the "AudioSource" game object
            if (audioSource == null)
            {
                audioSource = GameObject.Find("AudioSource").GetComponent<AudioSource>();
            }
        }

        // Update is called once per frame
        void Update()
        {
            // déplacement de l'objet
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        // Play a sound when the object is clicked
        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("OnPointerClick");
            PlayTheSoundAndDestroy();
        }

        public void OnHover(HoverEnterEventArgs args)
        {
            Debug.Log("OnHover");
            PlayTheSoundAndDestroy();
        }

        public void PlayTheSoundAndDestroy()
        {
            // if the distance between the object and the camera is less than 1.5
            if (Vector3.Distance(transform.position, Camera.main.transform.position) < 1.5f)
            {
                audioSource.PlayOneShot(clip);

                // Destroy the object
                Destroy(gameObject);
            }
        }
    }
}