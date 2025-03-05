using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Skip : MonoBehaviour
{
    public Text coupleText;
    public GameObject winPanel;
    public GameObject ZnakAnim;
    public GameObject skipText;

    private Hint hint;

    private bool skippedLevel;

    void Start()
    {
        hint = FindAnyObjectByType<Hint>();
    }

    public void SkipLevel()
    {
        if (hint != null && !hint.showingCards && !hint.hintUsed)
        {
            int currentCouple = int.Parse(coupleText.text);

            if (currentCouple >= 30)
            {
                SkipButtonText();
                currentCouple -= 30;
                coupleText.text = currentCouple.ToString();
                skippedLevel = true;
                SaveCoupleText();
            }
            else
            {
                if (ZnakAnim != null)
                {
                    ZnakAnim.SetActive(true);
                    StartCoroutine(DisableAnimation());
                }
                skippedLevel = false;
            }
        }
    }

    public bool DidSkipLevel()
    {
        return skippedLevel;
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

    private void SkipButtonText()
    {
        skipText.SetActive(true);
        winPanel.SetActive(true);
    }

    private void SaveCoupleText()
    {
        int currentCouple = int.Parse(coupleText.text);
        PlayerPrefs.SetInt("CoupleText", currentCouple);
        PlayerPrefs.Save();
    }

}
