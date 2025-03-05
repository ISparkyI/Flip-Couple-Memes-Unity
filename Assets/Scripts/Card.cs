using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Card : MonoBehaviour
{
    [SerializeField] private Game _game;
    [SerializeField] private Sprite _backSprite;
    private Sprite _frontSprite;
    [SerializeField] private Sprite _findSprite;

    public bool Down => GetComponent<Image>().sprite == _frontSprite;
    public bool Find => GetComponent<Image>().sprite == _findSprite;

    public void SetGame(Game game)
    {
        _game = game;
    }

    public Sprite GetFrontSprite()
    {
        return _frontSprite;
    }
    //phone
    public void OnTouch()
    {
        if (!_game.FindCard && !Find && !Down)
        {
            GetComponent<Image>().sprite = _frontSprite;
            _game.OpenCards();
            PlayFlipSound();
        }
    }
    //PC
    public void OnMouseDown()
    {
        if (!_game.FindCard && !Find && !Down)
        {
            GetComponent<Image>().sprite = _frontSprite;
            _game.OpenCards();
            PlayFlipSound();
        }
    }

    public void NoFindCard()
    {
        GetComponent<Image>().sprite = _backSprite;
        PlayFlipBackSound();
    }

    public void FindCard()
    {
        GetComponent<Image>().sprite = _findSprite;
        PlayFlipBackSound();
    }

    public void ShowFrontForOneSecond()
    {
        if (gameObject.activeSelf)
        {
            StartCoroutine(ShowFrontCoroutine());
        }
    }

    private IEnumerator ShowFrontCoroutine()
    {
        PlayFlipSound();
        GetComponent<Image>().sprite = _frontSprite;
        yield return new WaitForSeconds(2.5f);
        GetComponent<Image>().sprite = _backSprite;
        PlayFlipBackSound();
    }

    public void SetFrontSprite(Sprite sprite)
    {
        _frontSprite = sprite;
    }

    public void PlayFlipSound()
    {
        SoundManager.instance.PlayFlipSound();
    }

    public void PlayFlipBackSound()
    {
        SoundManager.instance.PlayFlipBackSound();
    }
}
