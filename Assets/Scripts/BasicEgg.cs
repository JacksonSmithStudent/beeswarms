using UnityEngine;

public class TokenPickup : MonoBehaviour
{
    public GameObject inventoryPanel;   // Your main inventory UI panel
    public GameObject tokenPanel;       // The token UI panel inside inventory, initially disabled

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (inventoryPanel != null)
                inventoryPanel.SetActive(true);   // Show inventory if it’s not shown already

            if (tokenPanel != null)
                tokenPanel.SetActive(true);       // Show the token panel in inventory

            Destroy(gameObject);                   // Remove token from the scene
        }
    }
}
