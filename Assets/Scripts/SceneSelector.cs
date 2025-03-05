using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelector : MonoBehaviour
{
    public void MenuScene()
    {
        SceneManager.LoadScene(0);
    }

    public void MainGameScene()
    {
        SceneManager.LoadScene(1);
    }

    public void CustomScene()
    {
        SceneManager.LoadScene(2);
    }

    public void SettingsScene()
    {
        SceneManager.LoadScene(3);
    }

    public void OnPlaySound()
    {
        SoundManager.instance.PlaySound();
    }
}
