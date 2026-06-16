using UnityEngine;
using UnityEngine.SceneManagement;

public class Flag : MonoBehaviour
{
    [Header("Level Transition")]
    [Tooltip("Exact name of the scene to load (must be added to Build Settings)")]
    public string nextLevel;

    [Tooltip("Optional delay before loading next level (in seconds)")]
    public float loadDelay = 0.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LoadNextLevel();
        }
    }

    private void LoadNextLevel()
    {
        if (string.IsNullOrEmpty(nextLevel))
        {
            Debug.LogError("Next level name is not set on the Flag!", this);
            return;
        }

        // Optional: Play win sound, animation, particles here
        
        Invoke(nameof(LoadScene), loadDelay);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(nextLevel);
    }
}