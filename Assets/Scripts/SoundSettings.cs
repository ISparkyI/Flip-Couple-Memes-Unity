using UnityEngine;

public class SoundSettings : MonoBehaviour
{
    public GameObject soundsOn;
    public GameObject soundsOff;

    private SoundManager soundManager;
    private bool isSoundOn = true; 

    void Start()
    {
        soundManager = FindAnyObjectByType<SoundManager>();

        isSoundOn = PlayerPrefs.GetInt("IsSoundOn", 1) == 1;
        UpdateSoundUI();

        if (soundManager != null)
        {
            soundManager.plupSound.enabled = isSoundOn;
            soundManager.flipSound.enabled = isSoundOn;
            soundManager.flipBackSound.enabled = isSoundOn;
        }
    }

    public void ToggleSound()
    {
        if (soundManager != null)
        {
            soundManager.plupSound.enabled = !soundManager.plupSound.enabled;
            soundManager.flipSound.enabled = !soundManager.flipSound.enabled;
            soundManager.flipBackSound.enabled = !soundManager.flipBackSound.enabled;
        }

        isSoundOn = !isSoundOn;
        PlayerPrefs.SetInt("IsSoundOn", isSoundOn ? 1 : 0);
        PlayerPrefs.Save(); 

        UpdateSoundUI();
    }

    private void UpdateSoundUI()
    {
        soundsOn.SetActive(isSoundOn);
        soundsOff.SetActive(!isSoundOn);
    }
}
