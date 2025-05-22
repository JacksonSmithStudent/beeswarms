using UnityEngine;

public class SimpleHive : MonoBehaviour
{
    public GameObject beePrefab; // Assign your Bee Cube prefab
    public Transform player;     // Drag the Player Transform here

    private bool playerInRange = false;
    private bool hiveClaimed = false;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!hiveClaimed)
            {
                hiveClaimed = true;
                Debug.Log("Hive claimed!");
            }
            else
            {
                SpawnBee();
            }
        }
    }

    void SpawnBee()
    {
        GameObject bee = Instantiate(beePrefab, transform.position + Vector3.up * 2, Quaternion.identity);
        bee.AddComponent<BeeFollower>().target = player;
        Debug.Log("Bee spawned!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
