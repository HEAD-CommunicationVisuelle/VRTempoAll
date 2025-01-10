using UnityEngine;
using UnityEngine.SceneManagement;

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
     Debug.Log("GameManager: All fobs are destroyed");

     //Load the next scene
     LoadNextScene();

    }

    void LoadNextScene()
    {
        Debug.Log("GameManager: LoadNextScene");

        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0; //Home scene
        }

        SceneManager.LoadScene(nextSceneIndex);



    }







}
