using UnityEngine;

public class InfoButton : MonoBehaviour
{
    public GameObject infopanel1;
    public GameObject infopanel2;
    public GameObject scroll;
    public GameObject backToMenu;

    public void OpenInfoPanel1()
    {
        backToMenu.SetActive(false);
        scroll.SetActive(false);
        infopanel1.SetActive(true);
    }

    public void OpenInfoPanel2()
    {
        backToMenu.SetActive(false);
        scroll.SetActive(false);
        infopanel2.SetActive(true);
    }

    public void closeButton()
    {
        backToMenu.SetActive(true);
        scroll.SetActive(true);
        infopanel1.SetActive(false);
        infopanel2.SetActive(false);
    }

    public void OnPlaySound()
    {
        SoundManager.instance.PlaySound();
    }
}
