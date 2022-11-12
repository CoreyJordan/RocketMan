using UnityEngine;
using UnityEngine.SceneManagement;


public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float delay = 1f;

    void OnCollisionEnter(Collision other)
    {
        // Reload on crash, load next level on finish.
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Bumped friendly.");
                break;
            case "Finish":
                StartNextLevelSequence();
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    void StartNextLevelSequence()
    {
        // Disabled flight controls, wait, and load next level.
        // todo add sound effect on crash
        // todo add particle effect on crash
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", delay);
    }

    void StartCrashSequence()
    {
        // Disable flight controls, pause, and reload level.
        // Add sound effect on finish.
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", delay);

    }

    void ReloadLevel()
    {
        // Reload the current level.
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadNextLevel()
    {
        // Load next level.
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
        
    }
}
