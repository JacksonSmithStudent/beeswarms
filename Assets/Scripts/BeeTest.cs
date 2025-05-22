using UnityEngine;

public class BeeFollower : MonoBehaviour
{
    public Transform target;
    public float followSpeed = 5f;

    void Update()
    {
        if (target == null) return;

        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * followSpeed * Time.deltaTime;
    }
}
