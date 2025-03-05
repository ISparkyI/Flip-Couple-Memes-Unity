using UnityEngine;
using UnityEngine.UI;

public class WinPanelManager : MonoBehaviour
{
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private Button _skipButton;
    [SerializeField] private Button _hintButton;
    [SerializeField] private Button _backToMenu;

    private void Start()
    {
        HideButtons();
    }

    private void Update()
    {
        if (_winPanel.activeSelf)
        {
            HideButtons();
        }
        else
        {
            ShowButtons();
        }
    }

    private void HideButtons()
    {
        _skipButton.gameObject.SetActive(false);
        _hintButton.gameObject.SetActive(false);
        _backToMenu.gameObject.SetActive(false);
    }

    private void ShowButtons()
    {
        _skipButton.gameObject.SetActive(true);
        _hintButton.gameObject.SetActive(true);
        _backToMenu.gameObject.SetActive(true);
    }
}
