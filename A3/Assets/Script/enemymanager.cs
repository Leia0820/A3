using UnityEngine;

public class enemeymanager : MonoBehaviour
{
    [SerializeField] private GameObject dad_monster;
    [SerializeField] private GameObject mom_monster;

    [SerializeField] private enemy_chase enemyChase;

    private void Start()
    {
        // Hide monsters at the beginning
        dad_monster.SetActive(false);
        mom_monster.SetActive(false);
    }

    public void StartEnemyChase()
    {
        // Show monsters
        dad_monster.SetActive(true);
        mom_monster.SetActive(true);

        // Start chasing
        enemyChase.StartChasing();
    }
}
