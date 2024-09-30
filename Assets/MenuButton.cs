using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    public Button mainMenuButton; // Reference to the button
    public CameraFade cameraFade; // Reference to CameraFade script

    private void Start()
    {
        if (mainMenuButton != null)
        {
            mainMenuButton.onClick.AddListener(LoadMainMenu);
        }
        else
        {
            Debug.LogError("Main Menu Button is not assigned!");
        }
    }

    private void LoadMainMenu()
    {
        cameraFade.FadeToBlack(() => SceneManager.LoadScene("MainMenu")); // Replace with your main menu scene name
    }
}
