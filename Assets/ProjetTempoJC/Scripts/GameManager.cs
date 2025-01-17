using UnityEngine;
using UnityEngine.SceneManagement;

namespace TempoJC
{

    public class GameManager : MonoBehaviour
    {


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            Fob.onFinsihed.AddListener(OnFobFinished);
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnFobFinished()
        {
            Debug.Log("GameManager: All Fobs are destroyed");

            //Load the next scene
            LoadNextScene();
        }

        void LoadNextScene()
        {
            Debug.Log("GameManager: LoadNextScene");

            // Get next scene index from the build settings
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;


            // if the next scene index is greater than the number of scenes in the building settings
            if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
            {
                nextSceneIndex = 0; // Home scene
            }
            SceneManager.LoadScene(nextSceneIndex);

        }
    }
}
