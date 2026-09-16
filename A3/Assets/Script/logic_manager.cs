using System;
using UnityEngine;

public class logic_manager : MonoBehaviour
{

    public static logic_manager instance;
    public int score;
    public event Action<int> OnScoreChange;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GainScore(int Value)
    {
        score = score + Value;
        OnScoreChange?.Invoke(score);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
