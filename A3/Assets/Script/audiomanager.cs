using UnityEngine;
using UnityEngine.SceneManagement;

public class audiomanager : MonoBehaviour
{
    [SerializeField] private AudioSource bgm;

    public static audiomanager instance;

    [System.Serializable]
    public class level_bgm
    {
        public string levelName;
        public AudioClip bgm;
    }

    [SerializeField] private level_bgm[] levels;

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

    private void Start()
    {
        PlaySceneMusic(SceneManager.GetActiveScene().name);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlaySceneMusic(scene.name);
    }

    private void PlaySceneMusic(string sceneName)
    {
        foreach (level_bgm level in levels)
        {
            if (level.levelName == sceneName)
            {
                bgm.clip = level.bgm;
                bgm.Play();
                return;
            }
        }
    }

    public void ChangeVolume(float volume)
    {
        bgm.volume = volume;
    }
}
