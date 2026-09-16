using UnityEngine;
using UnityEngine.SceneManagement;

public class complete_lvl1 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool OnTouchPlayer = collision.gameObject.CompareTag("Player");
        if(OnTouchPlayer && logic_manager.instance.score >= 10)
        {
            SceneManager.LoadScene("level_2");
        }
    }
}
