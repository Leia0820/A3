using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.XInput;

public class mc_ctrl : MonoBehaviour
{
    float xInput;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float Speed;
    [SerializeField] private int JumpPower;
    [SerializeField] private Transform ground_checker;
    [SerializeField] private Vector2 ground_checker_size;
    [SerializeField] private LayerMask ground;

    bool onGround;
    Vector3 Scale;
    private Animator animator;

    [Header("respawn point")]
    [SerializeField] private Transform respawn_point;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(ground_checker.position, ground_checker_size);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        // 确保重新进入关卡时玩家状态正常
        rb.simulated = true;
        playermanager.instance.ActionAllow = true;

        Debug.Log("MC START");
        Debug.Log("Rigidbody Simulated: " + rb.simulated);
        Debug.Log("MC Tag: " + gameObject.tag);
    }

    // Update is called once per frame
    void Update()
    {
        if (!playermanager.instance.ActionAllow)
        {
            return;
        }

        xInput = Input.GetAxis("Horizontal");
        rb.linearVelocityX = xInput * Speed;
        onGround = Physics2D.OverlapBox(ground_checker.position, ground_checker_size, 0, ground);
        if(Input.GetKeyDown("space") && onGround)
        {
            rb.linearVelocityY = JumpPower;
        }

        Scale = gameObject.transform.localScale;
        if (rb.linearVelocityX > 0)
        {
            Scale.x = Mathf.Abs(Scale.x);
        }
        else if (rb.linearVelocityX < 0)
        {
            Scale.x = -Mathf.Abs(Scale.x);
        }

        gameObject.transform.localScale = Scale; if (rb.linearVelocityX > 0)
        {
            Scale.x = Mathf.Abs(Scale.x);
        }
        else if (rb.linearVelocityX < 0)
        {
            Scale.x = -Mathf.Abs(Scale.x);
        }
        gameObject.transform.localScale = Scale;

        //Animation
        if (rb.linearVelocityX != 0)
        {
            animator.SetBool("iswalking", true);
        }
        else if(rb.linearVelocityX == 0)
        {
            animator.SetBool("iswalking", false);
        }
        if (onGround)
        {
            animator.SetBool("onGround", true);
        }
        else if (!onGround)
        {
            animator.SetBool("onGround", false);
            animator.SetFloat("jump", rb.linearVelocityY);
        }
    }

    public void onDead()
    {

        Debug.Log("PLAYER DEAD");

        playermanager.instance.LoseLifes(1);

        int CurrentLife = playermanager.instance.lifes;
        if(CurrentLife <= 0)
        {
            rb.simulated = false;
            animator.SetBool("isdead", true);
        }
        else
        {
            Debug.Log("RESPAWN");
            StartCoroutine(DeadRespawnAnimation());
        }
    }

    IEnumerator DeadRespawnAnimation()
    {
        rb.simulated = false;
        animator.SetBool("isdead", true);
        yield return new WaitForSeconds(1);

        animator.SetBool("isdead", false);
        gameObject.transform.position = respawn_point.position;

        animator.SetBool("isrevive", true);
        yield return new WaitForSeconds(1);

        animator.SetBool("isrevive", false);
        rb.simulated = true;
    }

    public void ResetAnimation()
    {
        animator.SetBool("isrevive", false);
        animator.SetBool("isdead", false);
        animator.SetFloat("jump", 0);
        animator.SetBool("onGround", false);
        animator.SetBool("iswalking", false);
    }
}
