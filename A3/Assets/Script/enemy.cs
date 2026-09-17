using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float Speed = 2f;

    private Transform player;
    private bool canChase = false;
    private Vector3 scale;

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

        if (player.position.x > transform.position.x)
        {
            transform.position += Vector3.right * Speed * Time.deltaTime;

            scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x);
            transform.localScale = scale;
        }
        else if (player.position.x < transform.position.x)
        {
            transform.position += Vector3.left * Speed * Time.deltaTime;

            scale = transform.localScale;
            scale.x = -Mathf.Abs(scale.x);
            transform.localScale = scale;
        }
    }

    public void StartChasing()
    {
        canChase = true;
    }

    public void StopChasing()
    {
        canChase = false;
    }
}