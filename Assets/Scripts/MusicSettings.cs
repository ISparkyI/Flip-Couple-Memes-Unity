using UnityEngine;

public class MusicSettings : MonoBehaviour
{
    public GameObject MusicOn;
    public GameObject MusicOff;

    private SoundManager soundManager;
    private bool isMusicOn = true;

    void Start()
    {
        soundManager = FindAnyObjectByType<SoundManager>();

        isMusicOn = PlayerPrefs.GetInt("isMusicOn", 1) == 1;
        UpdateMusicUI();

        if (soundManager != null)
        {
            soundManager.Music.enabled = isMusicOn;
        }
    }

    public void ToggleMusic()
    {
        if (soundManager != null)
        {
            soundManager.Music.enabled = !soundManager.Music.enabled;
        }

        isMusicOn = !isMusicOn;
        PlayerPrefs.SetInt("isMusicOn", isMusicOn ? 1 : 0);
        PlayerPrefs.Save();

        UpdateMusicUI();
    }

    private void UpdateMusicUI()
    {
        MusicOn.SetActive(isMusicOn);
        MusicOff.SetActive(!isMusicOn);
    }
}
