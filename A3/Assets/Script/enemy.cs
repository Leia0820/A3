using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float Speed = 2f;

    private Transform Player;
    private bool canChase = false;
    private Vector3 Scale;

    private void Awake()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            Player = playerObject.transform;
        }
    }

    private void Update()
    {
        if (Player == null || !canChase)
            return;

        if (Player.position.x > transform.position.x)
        {
            transform.position += Vector3.right * Speed * Time.deltaTime;

            Scale = transform.localScale;
            Scale.x = Mathf.Abs(Scale.x);
            transform.localScale = Scale;
        }
        else if (Player.position.x < transform.position.x)
        {
            transform.position += Vector3.left * Speed * Time.deltaTime;

            Scale = transform.localScale;
            Scale.x = -Mathf.Abs(Scale.x);
            transform.localScale = Scale;
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