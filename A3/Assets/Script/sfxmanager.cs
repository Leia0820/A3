using UnityEngine;

public class sfxmanager : MonoBehaviour
{
    [SerializeField] private AudioSource sfx;
    [SerializeField] private AudioClip buttonclicksfx;
    [SerializeField] private AudioClip walkingsfx;

    public static sfxmanager instance;

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

    public void ChangeVolume(float volume)
    {
        sfx.volume = volume;
    }

    public void buttonclick()
    {
        sfx.PlayOneShot(buttonclicksfx);
    }

    public void playwalking()
    {
        sfx.PlayOneShot(walkingsfx);
    }
}
