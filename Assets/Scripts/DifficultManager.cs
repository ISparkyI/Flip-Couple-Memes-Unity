using UnityEngine;
using UnityEngine.UI;

public class DifficultManager : MonoBehaviour
{
    public Button easyButton;
    public Button normalButton;
    public Button averageButton;
    public Button hardButton;
    public Button unrealButton;

    public GameObject _easyButton;
    public GameObject _normalButton;
    public GameObject _averageButton;
    public GameObject _hardButton;
    public GameObject _unrealButton;

    private string difficultyKey = "Difficulty";

    void Start()
    {

        LoadDifficulty();

        easyButton.onClick.AddListener(OnEasyButtonClick);
        normalButton.onClick.AddListener(OnNormalButtonClick);
        averageButton.onClick.AddListener(OnAverageButtonClick);
        hardButton.onClick.AddListener(OnHardButtonClick);
        unrealButton.onClick.AddListener(OnUnrealButtonClick);
    }

    void LoadDifficulty()
    {
        int difficulty = PlayerPrefs.GetInt(difficultyKey, 0);

        switch (difficulty)
        {
            case 0:
                OnEasyButtonClick();
                break;
            case 1:
                OnNormalButtonClick();
                break;
            case 2:
                OnAverageButtonClick();
                break;
            case 3:
                OnHardButtonClick();
                break;
            case 4:
                OnUnrealButtonClick();
                break;
        }
    }

    public void SaveDifficulty(int difficulty)
    {
        PlayerPrefs.SetInt(difficultyKey, difficulty);
        PlayerPrefs.Save();
    }

    public int GetCurrentDifficulty()
    {
        return PlayerPrefs.GetInt(difficultyKey, 0);
    }

    public void OnEasyButtonClick()
    {
        SaveDifficulty(0);
        GameManager.difficultyLevel = 1;
        easyButton.interactable = false;
        normalButton.interactable = true;
        _easyButton.SetActive(false);
        _normalButton.SetActive(true);
    }

    public void OnNormalButtonClick()
    {
        SaveDifficulty(1);
        GameManager.difficultyLevel = 2;
        normalButton.interactable = false;
        averageButton.interactable = true;
        _normalButton.SetActive(false);
        _averageButton.SetActive(true);
    }

    public void OnAverageButtonClick()
    {
        SaveDifficulty(2);
        GameManager.difficultyLevel = 3;
        averageButton.interactable = false;
        hardButton.interactable = true;
        _averageButton.SetActive(false);
        _hardButton.SetActive(true);
    }

    public void OnHardButtonClick()
    {
        SaveDifficulty(3);
        GameManager.difficultyLevel = 4;
        hardButton.interactable = false;
        unrealButton.interactable = true;
        _hardButton.SetActive(false);
        _unrealButton.SetActive(true);
    }

    public void OnUnrealButtonClick()
    {
        SaveDifficulty(4);
        GameManager.difficultyLevel = 0;
        unrealButton.interactable = false;
        easyButton.interactable = true;
        _unrealButton.SetActive(false);
        _easyButton.SetActive(true);
    }

    public void OnPlaySound()
    {
        SoundManager.instance.PlaySound();
    }
}
