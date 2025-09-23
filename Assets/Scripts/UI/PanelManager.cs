using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public static PanelManager Instance { get; private set; }

    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject[] structurePanels;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowStructurePanel(int structureIndex)
    {
        mainPanel.SetActive(false);
        
        for (int i = 0; i < structurePanels.Length; i++)
        {
            structurePanels[i].SetActive(i == structureIndex);
        }
    }

    public void ShowMainPanel()
    {
        mainPanel.SetActive(true);
        
        foreach (var panel in structurePanels)
        {
            panel.SetActive(false);
        }
    }
}