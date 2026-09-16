using UnityEngine;

public class kill_zone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool OnTouchPlayer = collision.gameObject.CompareTag("mc");
        if (OnTouchPlayer)
        {
            collision.GetComponent<mc_ctrl>().onDead();
        }
    }
}
