using UnityEngine;

public class dad_patrol : MonoBehaviour
{
    [SerializeField] private float Speed;

    private Transform enemy;
    private Transform LeftPoint;
    private Transform RightPoint;
    private Rigidbody2D rb;

    Vector3 Scale;

    // 一开始往左
    bool MovingRight = false;

    private void Awake()
    {
        enemy = transform.Find("dad_monster");
        LeftPoint = transform.Find("left");
        RightPoint = transform.Find("right");

        rb = enemy.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Scale = enemy.localScale;

        if (MovingRight)
        {
            // 往右走
            rb.linearVelocityX = Speed;

            if (enemy.position.x >= RightPoint.position.x)
            {
                MovingRight = false;
                Scale.x = -Mathf.Abs(Scale.x);
            }
        }
        else
        {
            // 往左走
            rb.linearVelocityX = -Speed;

            if (enemy.position.x <= LeftPoint.position.x)
            {
                MovingRight = true;
                Scale.x = Mathf.Abs(Scale.x);
            }
        }

        enemy.localScale = Scale;
    }
}