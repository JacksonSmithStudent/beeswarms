using UnityEngine;

public class HoneySaveManager : MonoBehaviour
{
    private const string HoneyKey = "Honey";

    private int honey = 0;

    public int Honey
    {
        get => honey;
        set
        {
            honey = value;
            SaveHoney();
        }
    }

    private void Awake()
    {
        LoadHoney();
    }

    public void SaveHoney()
    {
        PlayerPrefs.SetInt(HoneyKey, honey);
        PlayerPrefs.Save();
        Debug.Log("Honey saved: " + honey);
    }

    public void LoadHoney()
    {
        honey = PlayerPrefs.GetInt(HoneyKey, 0);
        Debug.Log("Honey loaded: " + honey);
    }
}
