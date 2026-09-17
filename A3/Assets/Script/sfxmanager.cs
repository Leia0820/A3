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
        if (!sfx.isPlaying)
        {
            sfx.clip = walkingsfx;
            sfx.loop = true;
            sfx.Play();
        }
    }

    public void stopwalking()
    {
        if (sfx.isPlaying)
        {
            sfx.Stop();
            sfx.loop = false;
        }
    }
}
