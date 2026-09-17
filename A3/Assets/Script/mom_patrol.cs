using UnityEngine;

public class mom_patrol : MonoBehaviour
{
    [SerializeField] private float Speed;

    private Transform enemy;
    private Transform LeftPoint;
    private Transform RightPoint;
    private Rigidbody2D rb;

    Vector3 Scale;

    bool MovingRight = true;

    private void Awake()
    {
        enemy = transform.Find("mom_monster");
        LeftPoint = transform.Find("left");
        RightPoint = transform.Find("right");

        rb = enemy.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Scale = enemy.localScale;

        if (MovingRight)
        {
            rb.linearVelocityX = Speed;

            if (enemy.position.x >= RightPoint.position.x)
            {
                MovingRight = false;
                Scale.x = Scale.x * -1;
            }
        }
        else
        {
            rb.linearVelocityX = -Speed;

            if (enemy.position.x <= LeftPoint.position.x)
            {
                MovingRight = true;
                Scale.x = Scale.x * -1;
            }
        }

        enemy.localScale = Scale;

    }
}