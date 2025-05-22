using UnityEngine;
using UnityEngine.UI;

public class MultiButtonTrigger : MonoBehaviour
{
    public Button[] buttons;
    private int currentButtonIndex = -1;

    public GameObject cameraCycleUIPanel;
    public CameraCycleController cameraCycleController;

    private bool playerInTrigger = false;

    void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i;
            buttons[i].onClick.AddListener(() => TriggerAction(index));
        }

        if (cameraCycleUIPanel != null)
            cameraCycleUIPanel.SetActive(false);

        if (cameraCycleController != null)
            cameraCycleController.DisableAllCameras();

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].gameObject.SetActive(i == 0);
        }

        if (buttons.Length > 0)
        {
            SetActiveButton(0);
        }
    }

    void Update()
    {
        if (playerInTrigger && Input.GetKeyDown(KeyCode.E) && currentButtonIndex >= 0)
        {
            TriggerAction(currentButtonIndex);
        }
    }

    public void SetActiveButton(int index)
    {
        if (index >= 0 && index < buttons.Length)
        {
            currentButtonIndex = index;
        }
        else
        {
            currentButtonIndex = -1;
        }
    }

    void TriggerAction(int index)
    {
        Debug.Log($"Action triggered from button {index}");

        switch (index)
        {
            case 0:
                if (cameraCycleUIPanel != null && cameraCycleController != null)
                {
                    bool isActive = cameraCycleUIPanel.activeSelf;
                    cameraCycleUIPanel.SetActive(!isActive);

                    if (!isActive)
                        cameraCycleController.EnableCamera(0);
                    else
                        cameraCycleController.DisableAllCameras();
                }

                buttons[0].gameObject.SetActive(false);
                if (buttons.Length > 1)
                {
                    buttons[1].gameObject.SetActive(true);
                    SetActiveButton(1);
                }

                break;

            case 1:
                if (cameraCycleUIPanel != null)
                    cameraCycleUIPanel.SetActive(false);

                if (cameraCycleController != null)
                    cameraCycleController.DisableAllCameras();

                buttons[1].gameObject.SetActive(false);
                if (buttons.Length > 0)
                {
                    buttons[0].gameObject.SetActive(true);
                    SetActiveButton(0);
                }

                break;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = true;
            // Optionally show UI prompt here
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = false;
            // Optionally hide UI prompt here
        }
    }
}
