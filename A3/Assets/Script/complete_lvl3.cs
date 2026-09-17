using UnityEngine;
using UnityEngine.SceneManagement;

public class complete_lvl3 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene("main_menu");
        }
    }
}
