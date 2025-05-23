using UnityEngine;

public class Tool : MonoBehaviour
{
    public float cooldown = 0.8f;
    private float lastUseTime = 0f;
    private Backpack backpack;
    private FlowerZoneDetector flowerZoneDetector;

    void Start()
    {
        // Find the backpack by tag
        GameObject backpackObject = GameObject.FindGameObjectWithTag("Backpack");
        if (backpackObject != null)
            backpack = backpackObject.GetComponent<Backpack>();

        if (backpack == null)
            Debug.LogError("Backpack not found! Make sure the 'Backpack' tag is on a GameObject with a Backpack component.");

        // Find the player and flower zone detector
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
            flowerZoneDetector = player.GetComponent<FlowerZoneDetector>();

        if (flowerZoneDetector == null)
            Debug.LogError("FlowerZoneDetector not found on player!");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time - lastUseTime >= cooldown)
        {
            if (flowerZoneDetector != null && flowerZoneDetector.isInFlowerZone)
            {
                if (backpack != null && backpack.currentPollen < backpack.maxPollen)
                {
                    backpack.AddPollen(2);
                    lastUseTime = Time.time;
                    Debug.Log("Collected 2 pollen!");
                }
            }
            else
            {
                Debug.Log("Not in flower zone.");
            }
        }
    }
}
