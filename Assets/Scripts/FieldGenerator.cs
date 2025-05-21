using UnityEngine;

public class FieldGenerator : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public GameObject fieldPrefab;
    public float spacing = 1f; // distance between fields

    void Start()
    {
        GenerateFields();
    }

    void GenerateFields()
    {
        if (fieldPrefab == null || startPoint == null || endPoint == null)
            return;

        Vector3 direction = (endPoint.position - startPoint.position).normalized;
        float distance = Vector3.Distance(startPoint.position, endPoint.position);

        int numFields = Mathf.FloorToInt(distance / spacing);

        for (int i = 0; i <= numFields; i++)
        {
            Vector3 spawnPos = startPoint.position + direction * spacing * i;
            Instantiate(fieldPrefab, spawnPos, Quaternion.identity);
        }
    }
}
