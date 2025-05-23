using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance; // Singleton

    public List<string> items = new List<string>();
    public TextMeshProUGUI inventoryDisplay; // Assign this in the inspector

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddItem(string itemName)
    {
        items.Add(itemName);
        UpdateInventoryUI();
    }

    void UpdateInventoryUI()
    {
        if (inventoryDisplay != null)
        {
            inventoryDisplay.text = "Inventory:\n";
            foreach (string item in items)
            {
                inventoryDisplay.text += "- " + item + "\n";
            }
        }
    }
}
