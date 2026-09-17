using UnityEngine;

public class enemeymanager : MonoBehaviour
{
    private Transform enemy;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        enemy = transform.Find("dad_monster");
        enemy = transform.Find("mom_monster");
    }
}
