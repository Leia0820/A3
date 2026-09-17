using UnityEngine;
using UnityEngine.SceneManagement;

public class complete_lvl2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene("level_3");
        }
    }
}
