using UnityEngine;

public class RulesManager : MonoBehaviour
{
    public GameObject rotateObject1;
    public GameObject rotateObject2;

    public GameObject rulesTub;

    void Start()
    {
        if (!PlayerPrefs.HasKey("FirstTimeOpened"))
        {
            rulesTub.SetActive(true);
            rotateObject1.SetActive(false);
            rotateObject2.SetActive(false);
            PlayerPrefs.SetInt("FirstTimeOpened", 1);
        }
    }

    public void OnButtonClicked()
    {
        rulesTub.SetActive(true);
        rotateObject1.SetActive(false);
        rotateObject2.SetActive(false);
    }

    public void BackButton()
    {
        rulesTub.SetActive(false);
        rotateObject1.SetActive(true);
        rotateObject2.SetActive(true);
    }
}
