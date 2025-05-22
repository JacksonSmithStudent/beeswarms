using UnityEngine;
using TMPro;

public class Backpack : MonoBehaviour
{
    public int currentPollen = 0;
    public int maxPollen = 200;
    public int currentHoney = 0;

    // 3D text on bag/player
    public TextMeshPro pollenDisplay3D;

    // UI menu texts
    public TextMeshProUGUI pollenDisplayUI;
    public TextMeshProUGUI honeyDisplayUI;

    void Start()
    {
        UpdatePollenDisplay();
        UpdateHoneyDisplay();
    }

    public void AddPollen(int amount)
    {
        if (currentPollen < maxPollen)
        {
            currentPollen = Mathf.Min(currentPollen + amount, maxPollen);
            UpdatePollenDisplay();
            UpdatePollenUI();
        }
    }


    // Update 3D text on bag
    public void UpdatePollenDisplay()
    {
        if (pollenDisplay3D != null)
        {
            pollenDisplay3D.text = $"Pollen: {currentPollen}/{maxPollen}";
        }
    }

    // Update pollen count on UI menu
    public void UpdatePollenUI()
    {
        if (pollenDisplayUI != null)
        {
            pollenDisplayUI.text = $"Pollen: {currentPollen}/{maxPollen}";
        }
    }

    // Update honey count on UI menu
    public void UpdateHoneyDisplay()
    {
        if (honeyDisplayUI != null)
        {
            honeyDisplayUI.text = $"Honey: {currentHoney}";
        }
    }

    // Call when converting pollen to honey
    public void ConvertPollenToHoney()
    {
        if (currentPollen > 0)
        {
            currentHoney += currentPollen;
            currentPollen = 0;

            UpdatePollenDisplay();
            UpdatePollenUI();
            UpdateHoneyDisplay();
        }
    }
}
