using UnityEngine;
using UnityEngine.UI;

public class LanguageManager : MonoBehaviour
{

    public GameObject bgLanguage;

    public void Language_change(int languageID)
    {
        PlayerPrefs.SetInt("Language", languageID);
        Translator.Select_language(PlayerPrefs.GetInt("Language"));
    }

    public void closeButton()
    {
        bgLanguage.SetActive(false);
    }

    public void LanguageButton() 
    {
        bgLanguage.SetActive(true);
    }
}
