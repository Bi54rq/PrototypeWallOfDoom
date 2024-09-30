using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    public string menuSceneName; // Name of your menu scene
    public CameraFade cameraFade; // Reference to CameraFade script

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cameraFade.FadeToBlack(() => LoadMenuScene());
        }
    }

    private void LoadMenuScene()
    {
        SceneManager.LoadScene(menuSceneName);
    }
}
