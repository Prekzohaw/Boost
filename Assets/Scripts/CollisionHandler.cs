using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelDelay = 1f;
    [SerializeField] AudioClip winSound;
    [SerializeField] AudioClip loseSound;

    AudioSource audioSource;

    bool isTransitioning = false;

    void Start() 
    {
        audioSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision other)
    {
        if (isTransitioning) { return; }

        switch (other.gameObject.tag)
        {
        case "Friendly":
         break;
        case "VictoryPad":
            StartFinishSequence();
            break;
        default:
            StartCrashSequence();
            break;
        }
    }

    void StartCrashSequence()
    {
        // todo add particles on crash
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(loseSound);
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", levelDelay);
    }

    void StartFinishSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(winSound);
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", levelDelay);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        isTransitioning = false;
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex+1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
        isTransitioning = false;
    }
}
