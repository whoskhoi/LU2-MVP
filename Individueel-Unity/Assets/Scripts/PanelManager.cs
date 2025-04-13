using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public GameObject panelPrefab;  
    public Transform parentContainer; 

    public void CreateNewPanel()
    {
        
        GameObject newPanel = Instantiate(panelPrefab, parentContainer);

    }
}