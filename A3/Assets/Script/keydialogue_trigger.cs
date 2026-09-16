using UnityEngine;

public class keydialogue_trigger : MonoBehaviour
{
    [SerializeField] private keydialogue_system keydialogue_manager;

    private Collider2D collide;

    private void Awake()
    {
        keydialogue_manager = GetComponentInParent<keydialogue_system>();
        collide = GetComponent<Collider2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Stop Player
            Rigidbody2D playerRb = collision.GetComponent<Rigidbody2D>();

            if (playerRb != null)
            {
                playerRb.linearVelocity = Vector2.zero;
            }

            // Reset player animation
            mc_ctrl player = collision.GetComponent<mc_ctrl>();

            if (player != null)
            {
                player.ResetAnimation();
            }

            // Stop player movement
            playermanager.instance.ActionAllow = false;

            // Start Dialogue
            keydialogue_manager.StartDialogue();

            // Ignore collision between Player and Key Trigger
            Physics2D.IgnoreCollision(collision, collide);
        }
    }
}