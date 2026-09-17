using UnityEngine;

public class kill_zone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Kill Zone touched: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player detected by Kill Zone");

            mc_ctrl player = collision.GetComponent<mc_ctrl>();

            if (player != null)
            {
                Debug.Log("Calling onDead()");
                player.onDead();
            }
            else
            {
                Debug.LogError("mc_ctrl not found on Player!");
            }
        }
    }
}
