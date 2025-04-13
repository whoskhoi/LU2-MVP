using UnityEngine;

public class BackManager : MonoBehaviour
{
    public static BackManager Instance;

    [Header("References")]
    public GameObject overviewPanel;
    public Transform parentContainer;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ToggleWorldView(bool show)
    {
        overviewPanel.SetActive(!show);
        parentContainer.gameObject.SetActive(show);
    }
}