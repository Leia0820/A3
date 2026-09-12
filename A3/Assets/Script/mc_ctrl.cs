using UnityEngine;

public class mc_ctrl : MonoBehaviour
{
    float xInput;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float Speed;
    [SerializeField] private int JumpPower;
    [SerializeField] private Transform ground_checker;
    [SerializeField] private Vector2 GroundCheckerSize;
    [SerializeField] private LayerMask Ground;

    bool onGround;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(ground_checker.position, GroundCheckerSize);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");

        rb.linearVelocityX = xInput * Speed;
        onGround = Physics2D.OverlapBox(ground_checker.position, GroundCheckerSize, 0, Ground);

        if (Input.GetKeyDown("space") && onGround)
        {
            rb.linearVelocityY = JumpPower;
        }
    }
}
