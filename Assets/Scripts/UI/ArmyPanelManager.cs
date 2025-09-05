using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class ArmyPanelManager : MonoBehaviour
{
    public GameObject unitPrefab; // Prefab que contiene la miniatura y el texto de cantidad
    public Transform armyPanel; // Panel donde se mostrarán las unidades
    private float yOffset;
    public List<UnitPO> army = new List<UnitPO>();
    public UnitFactory unitFactory = new UnitFactory();

    private void Start()
    {
        army = unitFactory.LoadArmy();
        yOffset = 450;
    }

    private void Update()
    {
        UpdateArmyPanel();
    }

    public void UpdateArmyPanel()
    {
        bool unitExist = false;
        //Convierto la lista de unidades a un diccionario que contiene cuantas unidades hay de cada tipo de unidad
        Dictionary<UnitType, int> numUnitsArmy = unitFactory.CountUnitsArmy(army);
        foreach (var numUnit in numUnitsArmy)
        {
            foreach (Transform child in armyPanel)
            {
                if (child.name == numUnit.Key.ToString())
                {
                    unitExist = true;
                    child.Find("Quantity").GetComponent<TextMeshProUGUI>().text = numUnit.Value.ToString();
                }
            }
            if (!unitExist && numUnit.Value != 0)
            {
                CreateUnitEntry(numUnit.Key, numUnit.Value);
                yOffset -= 120;
            }
            unitExist = false;
        }
    }

    private void CreateUnitEntry(UnitType unitType, int quantity)
    {
        GameObject newUnit = Instantiate(unitPrefab, armyPanel);

        newUnit.name = unitType.ToString();
        newUnit.transform.Find("Quantity").GetComponent<TextMeshProUGUI>().text = quantity.ToString();
        newUnit.transform.Find("Miniature").GetComponent<Image>().sprite = AsignUnitSprite(unitType);

        RectTransform rectTransform = newUnit.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(0, yOffset);
    }
    
    private Sprite AsignUnitSprite(UnitType unitType)
    {
        switch (unitType)
        {
            case UnitType.Archer:
                return Resources.Load<Sprite>($"Unit Icons/Felipe");
            case UnitType.GirlKnight:
                return Resources.Load<Sprite>($"Unit Icons/girlKnight");
            case UnitType.LeafArcher:
                return Resources.Load<Sprite>($"Unit Icons/LeafRanger");
            default:
                break;
        }
        return null;
    }
}