using UnityEngine;
using UnityEngine.UI;

public class LevelTextConnect : MonoBehaviour
{
    public Text levelText;

    void Start()
    {
        UpdateLevelText();
    }

    public void UpdateLevelText()
    {
        if (levelText != null)
        {
            int currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
            levelText.text = currentLevel.ToString();
        }
    }
}
