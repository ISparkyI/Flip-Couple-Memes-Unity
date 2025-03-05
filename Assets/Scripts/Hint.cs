using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Hint : MonoBehaviour
{
    private Game game;
    public Text CoupleText;
    public GameObject ZnakAnim;
    public bool showingCards;
    public bool hintUsed;

    void Start()
    {
        UpdateGameReference();
    }

    void UpdateGameReference()
    {
        game = FindAnyObjectByType<Game>();
    }

    public void UseHint()
    {
        UpdateGameReference();
        if (!showingCards && !hintUsed)
        {
            if (game == null)
            {
                game = FindAnyObjectByType<Game>();
            }

            if (game != null)
            {
                int currentCouple = int.Parse(CoupleText.text);

                if (currentCouple >= 12)
                {
                    int newCouple = (currentCouple - 12);
                    CoupleText.text = newCouple.ToString();
                    showingCards = true;
                    hintUsed = true;
                    SaveCoupleText();

                    foreach (Card card in game._cards)
                    {
                        if (card.transform.IsChildOf(game._panelCard))
                        {
                            if (!card.Find)
                            {
                                card.ShowFrontForOneSecond();
                            }
                        }
                    }
                    StartCoroutine(ResetShowingCards());
                }
                else
                {
                    if (ZnakAnim != null)
                    {
                        ZnakAnim.SetActive(true);
                        StartCoroutine(DisableAnimation());
                    }
                }
            }
        }
    }

    IEnumerator ResetShowingCards()
    {
        yield return new WaitForSeconds(4f);
        showingCards = false;
        hintUsed = false;
    }

    IEnumerator DisableAnimation()
    {
        yield return new WaitForSeconds(3.5f);
        ZnakAnim.SetActive(false);
    }

    public void OnPlaySound()
    {
        SoundManager.instance.PlaySound();
    }

    private void SaveCoupleText()
    {
        int currentCouple = int.Parse(CoupleText.text);
        PlayerPrefs.SetInt("CoupleText", currentCouple);
        PlayerPrefs.Save();
    }
}
