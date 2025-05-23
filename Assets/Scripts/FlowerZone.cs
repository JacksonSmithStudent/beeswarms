using UnityEngine;

public class FlowerZoneDetector : MonoBehaviour
{
    public bool isInFlowerZone = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Flower"))
        {
            isInFlowerZone = true;
            Debug.Log("Entered flower zone: " + other.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Flower"))
        {
            isInFlowerZone = false;
            Debug.Log("Exited flower zone: " + other.name);
        }
    }
}
