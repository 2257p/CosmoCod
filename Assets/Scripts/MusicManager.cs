using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;
    public AudioClip MainTheme;

    void Awake()
    {
        if (Instance != null) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        float savedVolume = PlayerPrefs.GetFloat("Volume", 0.5f);
        GetComponent<AudioSource>().volume = savedVolume * savedVolume;
    }

    void OnEnable() { SceneManager.sceneLoaded += OnSceneLoaded; }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (!audioSource.isPlaying) { audioSource.clip = MainTheme; audioSource.Play(); }
    }
}