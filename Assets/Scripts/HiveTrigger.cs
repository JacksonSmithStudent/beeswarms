using UnityEngine;

public class HiveTrigger : MonoBehaviour
{
    public GameObject hiveObject;           // Assign the hive GameObject this trigger belongs to
    public GameObject claimHiveCanvas;      // UI Canvas or panel for "Claim Hive"
    public GameObject convertHiveCanvas;    // UI Canvas or panel for "Convert Pollen"

    public bool isClaimed = false;

    private bool playerInRange = false;
    private GameObject playerInTrigger;

    void Awake()
    {
        if (hiveObject == null)
            hiveObject = this.gameObject;

        HideAllUI();
    }

    void Update()
    {

        if (!playerInRange || playerInTrigger == null)
        {
            HideAllUI();
            return;
        }

        var hiveManager = HiveClaimManager.Instance;

        if (hiveManager != null && hiveManager.CanClaimHive())
        {
            Debug.Log("Show claim UI");
            ShowClaimUI();

            if (!isClaimed && Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Claiming hive");
                hiveManager.ClaimHive(this);
                isClaimed = true;
                HideAllUI();

                Debug.Log("Hive claimed: " + hiveObject.name);

                var renderer = hiveObject.GetComponent<Renderer>();
                if (renderer != null)
                    renderer.material.color = Color.green;
            }
        }
        else if (hiveManager != null && hiveManager.IsPlayerHive(this))
        {
            Debug.Log("Player at own hive");

            Backpack backpack = playerInTrigger.GetComponentInChildren<Backpack>();
            if (backpack != null && backpack.currentPollen > 0)
            {
                Debug.Log($"Player has pollen: {backpack.currentPollen}");
                ShowConvertUI();

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Converting pollen to honey");
                    backpack.ConvertPollenToHoney(); 
                    HideAllUI();
                }
            }
            else
            {
                Debug.Log("No pollen to convert");
                HideAllUI();
            }
        }
        else
        {
            HideAllUI();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            playerInTrigger = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            playerInTrigger = null;

            HideAllUI();
        }
    }

    void ShowClaimUI()
    {
        if (claimHiveCanvas != null)
            claimHiveCanvas.SetActive(true);

        if (convertHiveCanvas != null)
            convertHiveCanvas.SetActive(false);
    }

    void ShowConvertUI()
    {
        if (convertHiveCanvas != null)
            convertHiveCanvas.SetActive(true);

        if (claimHiveCanvas != null)
            claimHiveCanvas.SetActive(false);
    }

    void HideAllUI()
    {
        if (claimHiveCanvas != null)
            claimHiveCanvas.SetActive(false);

        if (convertHiveCanvas != null)
            convertHiveCanvas.SetActive(false);
    }
}
