using UnityEngine;

public class HiveClaimManager : MonoBehaviour
{
    public static HiveClaimManager Instance;

    private bool hasClaimed = false;
    private HiveTrigger claimedHive;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public bool CanClaimHive()
    {
        return !hasClaimed;
    }

    public void ClaimHive(HiveTrigger hive)
    {
        claimedHive = hive;
        hasClaimed = true;
    }

    public bool IsPlayerHive(HiveTrigger hive)
    {
        return claimedHive == hive;
    }
}
