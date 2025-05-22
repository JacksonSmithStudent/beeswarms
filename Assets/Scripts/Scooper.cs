using UnityEngine;

public class Tool : MonoBehaviour
{
    public float cooldown = 0.8f;
    private float lastUseTime = 0f;

    private Backpack backpack;

    void Start()
    {
        // Look for the Backpack component on the object tagged "Backpack"
        GameObject backpackObject = GameObject.FindGameObjectWithTag("Backpack");
        if (backpackObject != null)
        {
            backpack = backpackObject.GetComponent<Backpack>();
        }

        if (backpack == null)
        {
            Debug.LogError("Backpack not found. Make sure the backpack GameObject has the 'Backpack' tag and a Backpack script.");
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time - lastUseTime >= cooldown)
        {
            if (backpack != null && backpack.currentPollen < backpack.maxPollen)
            {
                backpack.AddPollen(2); //  This is where it goes
                lastUseTime = Time.time;
            }
        }
    }
}
