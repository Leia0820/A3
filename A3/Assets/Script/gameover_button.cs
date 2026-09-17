using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButton : MonoBehaviour
{

    public void TestButton()
    {
        Debug.Log("BUTTON CLICKED!");
    }

    public void RetryLevel()
    {
        Debug.Log("========== RETRY CLICK ==========");

        string sceneName = SceneManager.GetActiveScene().name;

        Debug.Log("Current Scene: " + sceneName);

        SceneManager.LoadScene(sceneName);

        // Reset player lifes
        playermanager.instance.ResetLifes();

        // Reset player action
        playermanager.instance.ActionAllow = true;

    }

    // Go back to Main Menu
    public void GoToMainMenu()
    {
        Debug.Log("Going back to Main Menu");

        SceneManager.LoadScene("main_menu");
    }
}