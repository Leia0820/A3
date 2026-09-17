using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButton : MonoBehaviour
{
    // Restart the current level
    public void RetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Go back to Main Menu
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("main_menu");
    }
}