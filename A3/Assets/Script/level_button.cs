using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level_button : MonoBehaviour
{
    [SerializeField] private GameObject loading_screen;

    public void Playlevel_1()
    {
        StartCoroutine(Loadlevel());
    }
    
    IEnumerator Loadlevel()
    {
        loading_screen.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync("level_1");
        while (!operation.isDone)
        {
            yield return null;
        }
    }

}
