using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class ArmyPanelManager : MonoBehaviour
{
    public GameObject unitPrefab; // Prefab que contiene la miniatura y el texto de cantidad
    public Transform armyPanel; // Panel donde se mostrarán las unidades
    private Dictionary<string, int> armyUnits = GC.ARMY_UNITS;
    private float yOffset;
    
    private void Start(){
        armyUnits ??= GC.INITIAL_ARMY_2;
        GC.ARMY_UNITS = armyUnits;
        yOffset = 450;
    }

    private void Update()
    {
        UpdateArmyPanel();
    }

    public void UpdateArmyPanel()
    {
        bool unitExist = false;
        armyUnits = GC.ARMY_UNITS;
        foreach (var unit in armyUnits)
        {
            foreach (Transform child in armyPanel){
                if(child.name == unit.Key){
                    unitExist = true;
                    child.Find("Quantity").GetComponent<TextMeshProUGUI>().text = unit.Value.ToString();
                } 
            }
            if(!unitExist && unit.Value != 0){
                CreateUnitEntry(unit.Key, unit.Value);
                yOffset -= 120;
            }
            unitExist = false;
        }
    }
    
    private void CreateUnitEntry(string unitName, int quantity)
    {
        GameObject newUnit = Instantiate(unitPrefab, armyPanel);

        newUnit.name = unitName;
        newUnit.transform.Find("Quantity").GetComponent<TextMeshProUGUI>().text = quantity.ToString();
        newUnit.transform.Find("Miniature").GetComponent<Image>().sprite = GetUnitSprite(unitName);
        
        RectTransform rectTransform = newUnit.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(0, yOffset);
    }

    private Sprite GetUnitSprite(string unitName)
    {
        // Aquí deberías obtener el sprite correspondiente a la unidad
        return Resources.Load<Sprite>($"Unit Icons/{unitName}");
    }
}