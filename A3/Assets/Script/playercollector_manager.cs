using UnityEngine;

public class playercollector_manager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool OnTouchScore_1 = collision.gameObject.CompareTag("score +1");
        if (OnTouchScore_1)
        {
            logic_manager.instance.GainScore(1);
            Destroy(collision.gameObject);
        }
    }
}
