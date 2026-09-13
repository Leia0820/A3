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

    public void GameStart()
    {
        StartCoroutine(StartGameAsync());
    }

    IEnumerator StartGameAsync()
    {
        loading_screen.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync("level_selection");

        while (!operation.isDone)
        {
            yield return null;
        }
    }
    public void GoTolevel_1()
    {
        StartCoroutine(LevelStartAsync("level_1"));
    }

    IEnumerator LevelStartAsync(string level_1)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(level_1);
        loading_screen.SetActive(true);
        while (!operation.isDone)
        {
            //Progress Status here
            yield return null;
        }
    }

    public void Openoption()
    {
        option_screen.SetActive(true);
    }

    public void Closeoption()
    {
        option_screen.SetActive(false);
    }

    public void Exit_button()
    {
        Debug.Log("Exit");
        Application.Quit();
        EditorApplication.isPlaying = false;
    }

    public void V_slider_slide()
    {
        float volume = v_slider.value;
        audiomanager.instance.ChangeVolume(volume);
    }
    public void S_slider_slide()
    {
        float volume = s_slider.value;
        sfxmanager.instance.ChangeVolume(volume);
    }
    
    public void Activeoption_screen()
    {
        option_screen.SetActive(true);
    }
    public void Deactiveoption_screen()
    {
        option_screen.SetActive(false);
        sfxmanager.instance.buttonclick();
    }

    public void Playbuttonsfx()
    {
        sfxmanager.instance.buttonclick();
    }
}