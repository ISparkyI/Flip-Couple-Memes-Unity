using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinManager : MonoBehaviour
{
    public Sprite pinnedSprite;
    public Sprite notPinnedSprite;

    private string saveKey;

    void Start()
    {
        saveKey = gameObject.name + "_Pinned";
        LoadPinState();
    }

    public void OnPinButtonClick()
    {
        Sprite currentSprite = GetComponent<Image>().sprite;

        if (currentSprite == pinnedSprite)
        {
            return;
        }

        GetComponent<Image>().sprite = pinnedSprite;
        SavePinState();

        GameObject[] pins = GameObject.FindGameObjectsWithTag("Pin");
        foreach (GameObject pin in pins)
        {
            if (pin != gameObject)
            {
                pin.GetComponent<Image>().sprite = notPinnedSprite;
                pin.GetComponent<PinManager>().SavePinState();
            }
        }
    }

    void SavePinState()
    {
        PlayerPrefs.SetInt(saveKey, GetComponent<Image>().sprite == pinnedSprite ? 1 : 0);
        PlayerPrefs.Save();
    }

    void LoadPinState()
    {
        if (PlayerPrefs.HasKey(saveKey))
        {
            int state = PlayerPrefs.GetInt(saveKey);
            GetComponent<Image>().sprite = state == 1 ? pinnedSprite : notPinnedSprite;
        }
    }
}
