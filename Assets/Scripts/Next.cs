using UnityEngine;
using UnityEngine.UI;

public class Next : MonoBehaviour
{
    public Text levelText;
    public GameObject winPanel;
    public GameObject skipText;
    public GameObject znakAnim;
    private Game game;
    private Skip _skip;
    [SerializeField] private InterstitialAdManager interAdManager;

    public GameObject goodjob;
    public GameObject wellDone;
    public GameObject wonderful;
    public GameObject doitagain;

    public Text CoupleText;
    public static int randomCouple;

    public const string CoupleTextKey = "CoupleText";

    public void NextButtonClicked()
    {
        if (winPanel != null)
        {
            winPanel.SetActive(false);
            goodjob.SetActive(false);
            wellDone.SetActive(false);
            wonderful.SetActive(false);
            doitagain.SetActive(false);
            skipText.SetActive(false);
            znakAnim.SetActive(false);
        }
        if (game != null)
        {
            game.ResetAndShuffleCards();
            game.NextLevel();

        }
        if (_skip != null)
        {
            if (_skip != null && !_skip.DidSkipLevel())
            {
                game.NextLevel();
            }
        }
        if (interAdManager != null)
        {
            interAdManager.OnNextButtonClick();
        }
    }

    public void SetGame(Game gameRef)
    {
        game = gameRef;
    }

    public void ChangeCoupleText()
    {
        randomCouple = Random.Range(8, 16);
        int newCouple = int.Parse(CoupleText.text) + randomCouple;

        CoupleText.text = newCouple.ToString();

        PlayerPrefs.SetInt(CoupleTextKey, newCouple);
        PlayerPrefs.Save();
    }


    private void Start()
    {
        LoadCoupleText();
    }

    private void LoadCoupleText()
    {
        if (PlayerPrefs.HasKey(CoupleTextKey))
        {
            int savedCouple = PlayerPrefs.GetInt(CoupleTextKey);
            CoupleText.text = savedCouple.ToString();
        }
        else
        {
            CoupleText.text = "50";
            PlayerPrefs.SetInt(CoupleTextKey, 50);
            PlayerPrefs.Save();
        }
    }

    public void OnPlaySound()
    {
        SoundManager.instance.PlaySound();
    }

    public void SetInterAd(InterstitialAdManager manager)
    {
        interAdManager = manager;
    }
}
