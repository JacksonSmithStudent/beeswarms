using UnityEngine;

public class FieldSpawner : MonoBehaviour
{
    public Vector3 cornerA; // First corner of the field
    public Vector3 cornerB; // Opposite corner of the field

    public GameObject fieldTilePrefab; // Assign the prefab (e.g., flower, grass)
    public float spacing = 1f; // Distance between tiles

    public void SpawnField()
    {
        Vector3 min = Vector3.Min(cornerA, cornerB);
        Vector3 max = Vector3.Max(cornerA, cornerB);

        for (float x = min.x; x <= max.x; x += spacing)
        {
            for (float z = min.z; z <= max.z; z += spacing)
            {
                Vector3 spawnPos = new Vector3(x, min.y, z);
                Instantiate(fieldTilePrefab, spawnPos, Quaternion.identity);
            }
        }
    }

    // Optional: Automatically spawn on start
    void Start()
    {
        SpawnField();
    }
}
