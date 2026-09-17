using UnityEngine;
using UnityEngine.SceneManagement;

public class pause_button : MonoBehaviour
{
    [SerializeField] private GameObject pause_screen;

    public void PauseGame()
    {
        pause_screen.SetActive(true);

        Time.timeScale = 0f;

        playermanager.instance.ActionAllow = false;

    }

    public void ResumeGame()
    {
        pause_screen.SetActive(false);

        Time.timeScale = 1f;

        playermanager.instance.ActionAllow = true;
    }

    public void RetryLevel()
    {
        // Hide pause screen
        pause_screen.SetActive(false);

        // Reset game time
        Time.timeScale = 1f;

        // Reset player life
        playermanager.instance.ResetLifes();

        // Allow player to move
        playermanager.instance.ActionAllow = true;

        // Reload current level
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
    }

    public void GoToMainMenu()
    {
        // Hide pause screen
        pause_screen.SetActive(false);

        // Reset game time
        Time.timeScale = 1f;

        // Allow player to move
        playermanager.instance.ActionAllow = true;

        SceneManager.LoadScene("main_menu");
    }

    public void Closepause_screen()
    {
        pause_screen.SetActive(false);
    }
}
