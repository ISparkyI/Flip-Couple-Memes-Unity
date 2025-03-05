using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource plupSound;
    public AudioSource flipSound;
    public AudioSource flipBackSound;
    public AudioSource Music;

    private bool isSoundOn = true;
    private bool isMusicOn = true;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            plupSound = GetComponent<AudioSource>();

        }
        else
        {
            Destroy(gameObject);
            return;
        }

        isSoundOn = PlayerPrefs.GetInt("IsSoundOn", 1) == 1;
        UpdateSoundState();
        isMusicOn = PlayerPrefs.GetInt("isMusicOn", 1) == 1;
        UpdateMusicUI();
    }

    public void ToggleSound()
    {
        isSoundOn = !isSoundOn;
        PlayerPrefs.SetInt("IsSoundOn", isSoundOn ? 1 : 0);
        UpdateSoundState();
    }

    public void ToggleMusic()
    {
        isMusicOn = !isMusicOn;
        PlayerPrefs.SetInt("isMusicOn", isMusicOn ? 1 : 0);
        UpdateMusicUI();
    }

    private void UpdateSoundState()
    {
        plupSound.enabled = isSoundOn;
        flipSound.enabled = isSoundOn;
        flipBackSound.enabled = isSoundOn;
    }

    private void UpdateMusicUI()
    {
        Music.enabled = isMusicOn;
    }

    public void PlaySound()
    {
        if (plupSound != null && !plupSound.isPlaying)
        {
            plupSound.Play();
        }
    }

    public void PlayFlipSound()
    {
        if (flipSound != null && !flipSound.isPlaying)
        {
            flipSound.Play();
        }
    }

    public void PlayFlipBackSound()
    {
        if (flipBackSound != null && !flipBackSound.isPlaying)
        {
            flipBackSound.Play();
        }
    }

    void Start()
    {
        StartLanguage();
        if (Music != null)
        {
            Music.loop = true;
            Music.Play();
        }
    }

    private void StartLanguage()
    {
        if (PlayerPrefs.HasKey("Language") == false)
        {
            if (Application.systemLanguage == SystemLanguage.Ukrainian) PlayerPrefs.SetInt("Language", 1);
            else if (Application.systemLanguage == SystemLanguage.Russian) PlayerPrefs.SetInt("Language", 2);
            else PlayerPrefs.SetInt("Language", 0);
        }
        Translator.Select_language(PlayerPrefs.GetInt("Language"));
    }

}
