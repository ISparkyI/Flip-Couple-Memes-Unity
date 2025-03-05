using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform panel2x2;
    public Transform panel2x4;
    public Transform panel4x4;
    public Transform panel4x5;
    public Transform panel6x6;

    public GameObject _panel2x2;
    public GameObject _panel2x4;
    public GameObject _panel4x4;
    public GameObject _panel4x5;
    public GameObject _panel6x6;
    private Game _game;

    private string difficultyKey = "Difficulty";
    private string panelKey = "PanelKey";

    void Start()
    {
        SetGame(FindAnyObjectByType<Game>());
        DetermineLevel();
    }

    public void SetGame(Game game)
    {
        _game = game;
        DetermineLevel();
    }

    public void DetermineLevel()
    {
        int currentDifficulty = PlayerPrefs.GetInt(difficultyKey, 0);
        int savedPanelIndex = PlayerPrefs.GetInt(panelKey, 0);

        if (_game != null)
        {
            _panel2x2.SetActive(false);
            _panel2x4.SetActive(false);
            _panel4x4.SetActive(false);
            _panel4x5.SetActive(false);
            _panel6x6.SetActive(false);

            switch (currentDifficulty)
            {
                case 4:
                    _game.SetPanelCards(panel2x2);
                    _panel2x2.SetActive(true);
                    if (savedPanelIndex == 0)
                        _game.ShuffleCards();
                    break;
                case 0:
                    _game.SetPanelCards(panel2x4);
                    _panel2x4.SetActive(true);
                    if (savedPanelIndex == 1)
                        _game.ShuffleCards();
                    break;
                case 1:
                    _game.SetPanelCards(panel4x4);
                    _panel4x4.SetActive(true);
                    if (savedPanelIndex == 2)
                        _game.ShuffleCards();
                    break;
                case 2:
                    _game.SetPanelCards(panel4x5);
                    _panel4x5.SetActive(true);
                    if (savedPanelIndex == 3)
                        _game.ShuffleCards();
                    break;
                case 3:
                    _game.SetPanelCards(panel6x6);
                    _panel6x6.SetActive(true);
                    if (savedPanelIndex == 4)
                        _game.ShuffleCards();
                    break;
            }
        }
    }

    public void SaveDifficultyAndPanel(int difficulty, int panelIndex)
    {
        PlayerPrefs.SetInt(difficultyKey, difficulty);
        PlayerPrefs.SetInt(panelKey, panelIndex);
        PlayerPrefs.Save();
    }
}
