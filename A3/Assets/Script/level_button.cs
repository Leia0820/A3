using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level_button : MonoBehaviour
{
    [SerializeField] private GameObject loading_screen;

    // Level 1
    public void Playlevel_1()
    {
        StartCoroutine(Loadlevel("level_1"));
    }

    // Level 2
    public void Playlevel_2()
    {
        StartCoroutine(Loadlevel("level_2"));
    }

    // Level 3
    public void Playlevel_3()
    {
        StartCoroutine(Loadlevel("level_3"));
    }

    IEnumerator Loadlevel(string levelName)
    {
        loading_screen.SetActive(true);

        AsyncOperation operation = SceneManager.LoadSceneAsync(levelName);

        while (!operation.isDone)
        {
            yield return null;
        }
    }
}
