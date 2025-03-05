using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Collections;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public List<Sprite> _frontSprites = new List<Sprite>();
    public Transform _panelCard;
    [SerializeField] public List<Card> _cards;
    [SerializeField] private bool _findCard;
    [SerializeField] public GameObject _winPanel;

    [SerializeField] public GameObject[] winPhrases;

    public Text LevelText;
    public static int _currentLevel = 1;
    private const string LevelKey = "CurrentLevel";

    public bool FindCard => _findCard;

    private Skip _skip;

    private string _packName;

    public void Awake()
    {
        for (int i = 0; i < _panelCard.childCount; i++)
        {
            _panelCard.GetChild(i).transform.SetSiblingIndex(Random.Range(0, _panelCard.childCount));
        }
    }

    public void Start()
    {
        _packName = PlayerPrefs.GetString("SelectedPack", "AnimalsPack");
        LoadSpritesFromResources(_packName);
        SetPanelCards(_panelCard);
        InitializeGame();
        ShuffleCards();
        LoadLevel();
    }

    public void LoadLevel()
    {
        if (PlayerPrefs.HasKey(LevelKey))
        {
            _currentLevel = PlayerPrefs.GetInt(LevelKey);
            UpdateLevelText(_currentLevel);
        }
        else
        {
            PlayerPrefs.SetInt(LevelKey, _currentLevel);
            PlayerPrefs.Save();
        }
    }

    public void InitializeGame()
    {
        _cards.Clear();
        for (int i = 0; i < _panelCard.childCount; i++)
        {
            Card card = _panelCard.GetChild(i).GetComponent<Card>();
            card.SetGame(this);
            _cards.Add(card);
        }
        RandomizeSpritesAndPairs();
        Next nextScript = FindAnyObjectByType<Next>();
        if (nextScript != null)
        {
            nextScript.SetGame(this);
        }
    }

    private void LoadSpritesFromResources(string packName)
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>(packName);
        _frontSprites.AddRange(sprites);
    }

    public void RandomizeSpritesAndPairs()
    {
        _frontSprites.Clear();

        LoadSpritesFromResources(_packName);

        int cardsInPair = 2;
        int totalPairs = _cards.Count / cardsInPair;

        if (_frontSprites.Count < totalPairs)
        {
            Debug.LogError("Not enough sprites to form pairs.");
            return;
        }

        int[] spriteIndices = new int[_frontSprites.Count];
        for (int i = 0; i < spriteIndices.Length; i++)
        {
            spriteIndices[i] = i;
        }

        for (int i = 0; i < spriteIndices.Length; i++)
        {
            int temp = spriteIndices[i];
            int randomIndex = Random.Range(i, spriteIndices.Length);
            spriteIndices[i] = spriteIndices[randomIndex];
            spriteIndices[randomIndex] = temp;
        }

        for (int i = 0; i < totalPairs; i++)
        {
            int spriteIndex = spriteIndices[i];
            Sprite sprite = _frontSprites[spriteIndex];
            for (int j = 0; j < cardsInPair; j++)
            {
                int cardIndex = i * cardsInPair + j;
                _cards[cardIndex].SetFrontSprite(sprite);
            }
        }
    }



    public void OpenCards()
    {
        var openCards = _cards.Where(card => card.Down).ToList();

        if (openCards.Count == 2)
        {
            if (openCards[0].GetFrontSprite() == openCards[1].GetFrontSprite())
            {
                FindCards();
            }
            else
            {
                NoFindCards();
            }
        }
    }

    public void FindCards()
    {
        foreach (Card card in _cards)
        {
            if (card.Down)
            {
                StartCoroutine(Win(card));
            }
        }
    }

    public void NoFindCards()
    {
        foreach (Card card in _cards)
        {
            if (card.Down)
            {
                StartCoroutine(NoFind(card));
            }
        }
    }

    IEnumerator NoFind(Card card)
    {
        _findCard = true;
        yield return new WaitForSeconds(1f);
        card.GetComponent<Card>().NoFindCard();
        _findCard = false;
    }

    IEnumerator Win(Card card)
    {
        _findCard = true;
        yield return new WaitForSeconds(1f);
        card.GetComponent<Card>().FindCard();
        _findCard = false;
        Win();
    }

    public void Win()
    {
        var a = 0;

        foreach (Card card in _cards)
        {
            if (card.Find)
            {
                a++;
            }
        }

        if (a == _panelCard.childCount)
        {
            _winPanel.SetActive(true);
            UpdateCoupleText();
            int randomIndex = Random.Range(0, winPhrases.Length);
            for (int i = 0; i < winPhrases.Length; i++)
            {
                winPhrases[i].SetActive(i == randomIndex);
            }
        }
    }

    private void UpdateCoupleText()
    {
        FindAnyObjectByType<Next>().ChangeCoupleText();
    }

    public void ResetAndShuffleCards()
    {
        _cards.Clear();

        for (int i = 0; i < _panelCard.childCount; i++)
        {
            _panelCard.GetChild(i).transform.SetSiblingIndex(Random.Range(0, _panelCard.childCount));
        }

        for (int i = 0; i < _panelCard.childCount; i++)
        {
            _cards.Add(_panelCard.GetChild(i).GetComponent<Card>());
        }

        foreach (Card card in _cards)
        {
            card.GetComponent<Card>().NoFindCard();
        }
    }

    public void ShowAllCardsForOneSecond()
    {
        foreach (Card card in _cards)
        {
            card.ShowFrontForOneSecond();
        }
    }

    public void NextLevel()
    {
        _currentLevel++;
        UpdateLevelText(_currentLevel);
        SaveLevel();

        if (_skip != null && !_skip.DidSkipLevel())
        {
            UpdateCoupleText();
        }

        FindAnyObjectByType<LevelManager>().DetermineLevel();
        Start();
    }

    public void ShuffleCards()
    {
        for (int i = 0; i < _panelCard.childCount; i++)
        {
            _panelCard.GetChild(i).transform.SetSiblingIndex(Random.Range(0, _panelCard.childCount));
        }
    }

    private void UpdateLevelText(int newLevel)
    {
        if (LevelText != null)
        {
            LevelText.text = newLevel.ToString();
        }
    }

    public void SaveLevel()
    {
        PlayerPrefs.SetInt(LevelKey, _currentLevel);
        PlayerPrefs.Save();
    }

    public void SetPanelCards(Transform panel)
    {
        _panelCard = panel;
        ShuffleCards();
    }
}