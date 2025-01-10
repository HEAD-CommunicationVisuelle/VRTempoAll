using UnityEngine;
using UnityEngine.SceneManagement;

namespace TempoPR
{

    public class GameManager : MonoBehaviour
    {

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            Fob.onFinished.AddListener(OnFobFinished);
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnFobFinished()
        {
            Debug.Log("GameManager: All Fobs are destroyed");

            // Load the next scene
            LoadNextScene();
        }

        void LoadNextScene()
        {
            Debug.Log("GameManager: LoadNextScene");

            // Get next scene index from the build settings
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

            // If the next scene index is greater than the number of scenes in the build settings
            if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
            {
                // Load the first scene
                nextSceneIndex = 0;
            }

            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}