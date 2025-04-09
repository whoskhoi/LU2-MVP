using UnityEngine;

public class PanelSwitcher : MonoBehaviour
{
    public GameObject currentPanel;
    public GameObject targetPanel;

    public void SwitchPanel()
    {
        if (currentPanel != null) currentPanel.SetActive(false);
        if (targetPanel != null) targetPanel.SetActive(true);
    }
}
