using UnityEngine;

public class dialogue_trigger : MonoBehaviour
{
    [SerializeField] private dialogue_system dialogue_manager;

    private Collider2D collide;
    private void Awake()
    {
        dialogue_manager = GetComponentInParent<dialogue_system>();
        collide = GetComponent<Collider2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool DialogueTriggerObj = collision.gameObject.CompareTag("Player");
        if (DialogueTriggerObj)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().linearVelocity = new Vector3(0, 0, 0);
            collision.gameObject.GetComponent<mc_ctrl>().ResetAnimation();

            playermanager.instance.ActionAllow = false;

            dialogue_manager.TriggerToTrue(true);
            dialogue_manager.StartDialogue();
            Physics2D.IgnoreCollision(collision, collide);
        }
    }
}
