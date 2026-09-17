using UnityEngine;

public class monster_damage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            mc_ctrl player = collision.GetComponent<mc_ctrl>();

            if (player != null)
            {
                player.onDead();
            }
        }
    }
}
