using UnityEngine;

public class PackSelector : MonoBehaviour
{
    public string defaultPackName = "AnimalsPack";

    private void Start()
    {
        string savedPackName = PlayerPrefs.GetString("SelectedPack", defaultPackName);
        SetPack(savedPackName);
    }

    public void OnAnimalsPack()
    {
        SetPack("AnimalsPack");
    }

    public void OnRandomPack1()
    {
        SetPack("RandomPack1");
    }

    private void SetPack(string packName)
    {
        PlayerPrefs.SetString("SelectedPack", packName);
        PlayerPrefs.Save();
    }
}
