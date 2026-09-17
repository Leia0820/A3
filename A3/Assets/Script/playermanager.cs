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

    public void ResetLifes()
    {
        lifes = 3;
        OnLifesChange?.Invoke(lifes);
    }
}
