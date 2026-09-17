using UnityEngine;

public class key_trigger_enemy : MonoBehaviour
{
    [SerializeField] private enemy_chase enemyChase;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemyChase.StartChasing();
        }
    }
}
