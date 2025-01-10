using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Fob.onFinish.AddListener(OnFobFinish);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnFobFinish()
    {
        Debug.Log("YEAH ! All fobs have been destroyed");

        // Load the next scene
        LoadNextScene();
    }

    void LoadNextScene()
    {
        Debug.Log("GameManager : LoadNextScene");

        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0; // Home screen
        }
            SceneManager.LoadScene(nextSceneIndex);
    }
}
