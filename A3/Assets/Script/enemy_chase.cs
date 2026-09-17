using UnityEngine;

public class enemy_chase : MonoBehaviour
{
    [Header("Enemy")]
    [SerializeField] private Transform dad_monster;
    [SerializeField] private Transform mom_monster;

    [Header("Chase")]
    [SerializeField] private float speed = 0.5f;
    [SerializeField] private bool canChase = false;

    [Header("Chase Range")]
    [SerializeField] private Transform left_point;
    [SerializeField] private Transform right_point;

    private Transform player;

    private void Awake()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    private void Update()
    {
        if (player == null || !canChase)
            return;

        // MC 在追逐范围内
        if (player.position.x >= left_point.position.x &&
            player.position.x <= right_point.position.x)
        {
            ChaseEnemy(dad_monster);
            ChaseEnemy(mom_monster);
        }
        else
        {
            // MC 离开范围
            StopEnemy(dad_monster);
            StopEnemy(mom_monster);
        }
    }

    private void ChaseEnemy(Transform enemy)
    {
        if (enemy == null)
            return;

        Vector3 scale = enemy.localScale;

        if (player.position.x > enemy.position.x)
        {
            enemy.position += Vector3.right * speed * Time.deltaTime;

            scale.x = Mathf.Abs(scale.x);
        }
        else if (player.position.x < enemy.position.x)
        {
            enemy.position += Vector3.left * speed * Time.deltaTime;

            scale.x = -Mathf.Abs(scale.x);
        }

        enemy.localScale = scale;
    }

    private void StopEnemy(Transform enemy)
    {
        if (enemy == null)
            return;

        Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.linearVelocityX = 0;
        }
    }

    public void StartChasing()
    {
        canChase = true;
    }

    public void StopChasing()
    {
        canChase = false;

        StopEnemy(dad_monster);
        StopEnemy(mom_monster);
    }
}