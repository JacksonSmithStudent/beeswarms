using UnityEngine;

public class ToggleUI : MonoBehaviour
{
    public GameObject uiToToggle; // Assign the UI panel or element to toggle

    private bool isVisible = false;

    public void Toggle()
    {
        isVisible = !isVisible;
        if (uiToToggle != null)
        {
            uiToToggle.SetActive(isVisible);
        }
    }
}
