using NUnit.Framework;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class audiomanager : MonoBehaviour
{
    [SerializeField] private AudioSource bgm;

    public static audiomanager instance;

    [System.Serializable]
    public class level_bgm
    {
        public string level_1;
        public AudioClip bgm;
    }

    [SerializeField] private List<level_bgm> levelbgm;

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
        foreach (level_bgm level in levelbgm)
        {
            if (level.level_1 == sceneName)
            {
                bgm.clip = level.bgm;
                bgm.Play();
                return;
            }
        }
    }
}
