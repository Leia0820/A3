using UnityEngine;

public class keyinstructor : MonoBehaviour
{

    [SerializeField] private GameObject instruction;

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
        bool OnTouchPlayer = collision.gameObject.CompareTag("mc");
        if (OnTouchPlayer)
        {
            instruction.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        bool OnTouchPlayer = collision.gameObject.CompareTag("mc");
        if (OnTouchPlayer)
        {
            instruction.SetActive(false);
        }
    }
}
