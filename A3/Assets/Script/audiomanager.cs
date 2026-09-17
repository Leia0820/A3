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
        Debug.Log("Current Scene: " + sceneName);

        foreach (level_bgm level in levels)
        {
            Debug.Log("Checking Level: " + level.levelName);

            if (level.levelName == sceneName)
            {
                Debug.Log("BGM FOUND: " + level.bgm);

                if (bgm.clip == level.bgm && bgm.isPlaying)
                {
                    Debug.Log("This BGM is already playing.");
                    return;
                }

                bgm.clip = level.bgm;
                bgm.Play();

                Debug.Log("Playing BGM: " + level.bgm.name);

                return;
            }
        }

        Debug.LogWarning("No BGM found for scene: " + sceneName);
    }

    public void ChangeVolume(float volume)
    {
        bgm.volume = volume;
    }
}