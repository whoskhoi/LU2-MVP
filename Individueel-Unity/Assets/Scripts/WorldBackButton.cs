using UnityEngine;
using UnityEngine.UI;

public class WorldBackButton : MonoBehaviour
{
    public GameObject worldPanel;

    public void WorldPanelToggle()
    {
        worldPanel.SetActive(false);
    }
}