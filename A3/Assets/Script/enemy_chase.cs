using UnityEngine;

public class enemy_chase : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private bool canChase = false;
    private Transform enemy;
    private Transform left_point;
    private Transform right_point;
    Rigidbody2D rb;
    Vector3 scale;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void Awake()
    {
        enemy = transform.Find("dad_monster");
        enemy = transform.Find("mom_monster");
        left_point = transform.Find("left");
        right_point = transform.Find("right");
        rb = enemy.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        bool onTouchPlayer = collision.gameObject.CompareTag("Player");
        if (onTouchPlayer && canChase)
        {
            Vector3 player_position = collision.gameObject.transform.position;
            scale = enemy.localScale;

            if (enemy.position.x < player_position.x && enemy.position.x < right_point.position.x)
            {
                rb.linearVelocityX = speed * 1;
                if (scale.x < 0)
                {
                    scale.x = scale.x * -1;
                }
            }
            else if (enemy.position.x > player_position.x && enemy.position.x > right_point.position.x)
            {
                rb.linearVelocityX = speed * -1;
                if (scale.x > 0)
                {
                    scale.x = scale.x * -1;
                }
            }

            enemy.localScale = scale;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.linearVelocityX = 0;
        }

    }

    public void StartChasing()
    {
        canChase = true;
    }

}
