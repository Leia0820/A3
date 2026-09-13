using System;
using UnityEngine;

public class playermanager : MonoBehaviour
{
    public static playermanager instance;
    public int lifes;
    public event Action<int> OnLifesChange;
    public bool ActionAllow = true;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GainLifes(int Value)
    {
        lifes = lifes + Value;
        OnLifesChange?.Invoke(lifes);
    }

    public void LoseLifes(int Value)
    {
        lifes = lifes - Value;
        OnLifesChange?.Invoke(lifes);
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
