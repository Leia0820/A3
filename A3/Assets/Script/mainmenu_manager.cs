using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainmenu_manager : MonoBehaviour
{
    [SerializeField] private Slider v_slider;
    [SerializeField] private Slider s_slider;
    [SerializeField] private GameObject option_screen;
    [SerializeField] private GameObject loading_screen;


    // START BUTTON
    // 直接进入 Level 1
    public void GameStart()
    {
        StartCoroutine(LevelStartAsync("level_1"));
    }


    // LEVEL SELECT BUTTON
    // 进入 Level Selection
    public void GoToLevelSelect()
    {
        StartCoroutine(StartGameAsync());
    }


    // Load Level Selection
    IEnumerator StartGameAsync()
    {
        loading_screen.SetActive(true);

        AsyncOperation operation =
            SceneManager.LoadSceneAsync("level_selection");

        while (!operation.isDone)
        {
            yield return null;
        }
    }


    // Load Level
    IEnumerator LevelStartAsync(string levelName)
    {
        loading_screen.SetActive(true);

        AsyncOperation operation =
            SceneManager.LoadSceneAsync(levelName);

        while (!operation.isDone)
        {
            yield return null;
        }
    }


    // OPTION
    public void Openoption()
    {
        option_screen.SetActive(true);
    }

    public void Closeoption()
    {
        option_screen.SetActive(false);
    }


    // EXIT
    public void exit_button()
    {
        Debug.Log("Exit");

        Application.Quit();

#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
    }


    // VOLUME
    public void v_slider_slide()
    {
        float volume = v_slider.value;
        audiomanager.instance.ChangeVolume(volume);
    }


    // SFX VOLUME
    public void s_slider_slide()
    {
        float volume = s_slider.value;
        sfxmanager.instance.ChangeVolume(volume);
    }


    public void open_option_screen()
    {
        option_screen.SetActive(true);
    }

    public void cloase_option_screen()
    {
        option_screen.SetActive(false);
        sfxmanager.instance.buttonclick();
    }


    // BUTTON SFX
    public void Playbuttonsfx()
    {
        sfxmanager.instance.buttonclick();
    }
}