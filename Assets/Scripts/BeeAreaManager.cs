using UnityEngine;

public class BeeAreaManager : MonoBehaviour
{
    [Header("Bee Count (Editable in Inspector)")]
    public int beeCount = 0;

    [System.Serializable]
    public class BeeArea
    {
        public GameObject areaObject;          // Area visuals (optional)
        public GameObject lockedGate;          // Gate that blocks player
        public GameObject unlockedGate;        // Replacement gate that allows access
        public int requiredBeeCount;
        public bool isUnlocked = false;
    }

    [Header("Bee Areas")]
    public BeeArea[] beeAreas;

    void Update()
    {
        CheckUnlocks();
    }

    void CheckUnlocks()
    {
        foreach (BeeArea area in beeAreas)
        {
            if (!area.isUnlocked && beeCount >= area.requiredBeeCount)
            {
                if (area.areaObject != null)
                    area.areaObject.SetActive(true);

                if (area.lockedGate != null)
                    area.lockedGate.SetActive(false); // Hide the locked gate

                if (area.unlockedGate != null)
                    area.unlockedGate.SetActive(true); // Show the unlocked gate

                area.isUnlocked = true;
                Debug.Log("Unlocked bee area: " + area.areaObject?.name);
            }
        }
    }
}
