using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource musicSource;
    public AudioSource sfxSource;

    private bool musicOn = true;
    private bool soundOn = true;

    private void Start()
    {
        musicOn = PlayerPrefs.GetInt("Music", 1) == 1;
        soundOn = PlayerPrefs.GetInt("Sound", 1) == 1;

        musicSource.mute = !musicOn;
        sfxSource.mute = !soundOn;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ToggleMusic()
    {
        musicOn = !musicOn;
        musicSource.mute = !musicOn;
    }

    public void ToggleSound()
    {
        soundOn = !soundOn;
        sfxSource.mute = !soundOn;
    }
}