using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class ArmyPanelManager : MonoBehaviour
{
    public GameObject unitPrefab; // Prefab que contiene la miniatura y el texto de cantidad
    public GameObject unitIconPrefab; 
    public Transform armyPanel; // Panel donde se mostrarán las unidades
    public Transform bottomPanel;
    public static List<UnitPO> army = new List<UnitPO>();
    public UnitFactory unitFactory = new UnitFactory();
    public UnitType newUnitType;
    
    private void Start()
    {
        army = unitFactory.LoadArmy();
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

        newUnit.GetComponent<Button>().onClick.AddListener(() =>
        {
            OnUnitClicked(unitType);
        });
    }
    
    public void OnUnitClicked(UnitType unitType)
    {
        // 1. Limpiar el panel inferior
        foreach (Transform child in bottomPanel)
        {
            Destroy(child.gameObject);
        }

        // 2. Crear iconos para cada unidad del tipo seleccionado
        foreach (var unit in army)
        {
            if (unit.UnitType == unitType)
            {
                CreateUnitIcon(unit);
            }
        }
    }

    public void CreateUnitIcon(UnitPO unit)
    {
        GameObject icon = Instantiate(unitIconPrefab, bottomPanel);
        UnitIcon unitIcon = icon.GetComponent<UnitIcon>();
        if (unitIcon == null)
        {
            unitIcon = icon.AddComponent<UnitIcon>();
        }
        unitIcon.SetUnitData(unit);
        
        // Configurar el sprite del icono
        Image iconImage = icon.GetComponent<Image>();
        if (iconImage != null)
        {
            iconImage.sprite = AsignUnitSprite(unit.UnitType);
        }
    }

    public void AddNewUnit()
    {
        army.Add(unitFactory.CreateNewUnitPO(newUnitType));
        OnUnitClicked(newUnitType);
        GameSaveManager.Save(unitFactory.UnitToUnitData(army), DataType.ArmyData);
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