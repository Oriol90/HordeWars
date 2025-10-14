using UnityEngine;
using TMPro;
using System;
using System.Collections.Generic;

public class CourtyardManager : MonoBehaviour
{
    [Header("Dropdowns")]
    public TMP_Dropdown rarityDropdown;
    public TMP_Dropdown levelDropdown;
    public TMP_Dropdown unitTypeDropdown;

    [Header("GO itemIcon")]
    public GameObject unitIconPrefab;
    public Transform unitCourtyardGrid;
    public Transform armyGrid;

    private UnitFactory unitFactory = new UnitFactory();
    private List<UnitPO> courtyardUnits;
    private List<UnitPO> army;

    private void Awake()
    {
        courtyardUnits = unitFactory.CourtYardUnits();
        army = unitFactory.LoadArmy();
    }

    private void Start()
    {
        PopulateDropdowns();
        PopulateUnitList();
    }

    private void PopulateDropdowns()
    {

        List<string> levelOptions = new List<string>();
        for (int i = 1; i <= 6; i++)
        {
            levelOptions.Add(i.ToString());
        }

        List<string> rarityOptions = new(Enum.GetNames(typeof(Rarity)));
        List<string> unitOptions = new(Enum.GetNames(typeof(UnitType)));

        // --- RAREZA ---
        rarityDropdown.ClearOptions();
        rarityOptions.Insert(0, "All");
        rarityDropdown.AddOptions(rarityOptions);

        // --- NIVEL ---
        levelDropdown.ClearOptions();
        levelOptions.Insert(0, "All");
        levelDropdown.AddOptions(levelOptions);

        // --- TIPO DE UNIDAD ---
        unitTypeDropdown.ClearOptions();
        unitOptions.Insert(0, "All");
        unitTypeDropdown.AddOptions(unitOptions);

        rarityDropdown.value = 0;
        unitTypeDropdown.value = 0;
        levelDropdown.value = 0;

        rarityDropdown.onValueChanged.AddListener(OnRarityChanged);
        unitTypeDropdown.onValueChanged.AddListener(OnUnitTypeChanged);
        levelDropdown.onValueChanged.AddListener(OnLevelChanged);
    }

    private void OnRarityChanged(int index)
    {
        GC.COURTYARD_SELECTED_RARITY = index;
        FilterItemsBySelection(unitCourtyardGrid);
        FilterItemsBySelection(armyGrid);
    }

    private void OnUnitTypeChanged(int index)
    {
        GC.COURTYARD_SELECTED_UNIT = index;
        FilterItemsBySelection(unitCourtyardGrid);
        FilterItemsBySelection(armyGrid);
    }

    private void OnLevelChanged(int index)
    {
        GC.COURTYARD_SELECTED_LEVEL = index;
        FilterItemsBySelection(unitCourtyardGrid);
        FilterItemsBySelection(armyGrid);
    }

    private void PopulateUnitList()
    {
        foreach (Transform child in unitCourtyardGrid){
            Destroy(child.gameObject);
        }

        foreach (Transform child in armyGrid){
            Destroy(child.gameObject);
        }

        foreach (var unit in courtyardUnits)
        {
            CreateCourtyardUnitEntry(unit);
        }

        foreach (var unit in army)
        {
            CreateArmyUnitEntry(unit);
        }
    }

    private void CreateCourtyardUnitEntry(UnitPO unit)
    {
        GameObject unitIconGO = Instantiate(unitIconPrefab, unitCourtyardGrid);
        UnitIcon unitIcon = unitIconGO.GetComponent<UnitIcon>();

        unitIcon.SetUp(unit, true);
    }

    private void CreateArmyUnitEntry(UnitPO unit)
    {
        GameObject unitIconGO = Instantiate(unitIconPrefab, armyGrid);
        UnitIcon unitIcon = unitIconGO.GetComponent<UnitIcon>();

        unitIcon.SetUp(unit, false);
    }

    private void FilterItemsBySelection(Transform grid)
    {

        foreach (Transform child in grid)
        {
            UnitPO unit = child.GetComponent<UnitIcon>().unitPO;
            ItemData itemData = ItemDBStatic.Get(unit.EquippedItem);
            if ((GC.COURTYARD_SELECTED_RARITY == 0 || itemData.Rarity == (Rarity)(GC.COURTYARD_SELECTED_RARITY - 1)) &&
                (GC.COURTYARD_SELECTED_UNIT == 0 || unit.UnitType == (UnitType)(GC.COURTYARD_SELECTED_UNIT - 1)) &&
                (GC.COURTYARD_SELECTED_LEVEL == 0 || unit.Level == GC.COURTYARD_SELECTED_LEVEL))
            {
                child.gameObject.SetActive(true);
            }
            else
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    public void SwitchUnits()
    {
        bool marked;
        List<UnitPO> newCourtyardUnits = new List<UnitPO>();
        List<UnitPO> newArmy = new List<UnitPO>();

        foreach (Transform child in unitCourtyardGrid)
        {
            marked = child.GetComponent<UnitIcon>().arrowDownImage.gameObject.activeSelf;
            if (marked)
            {
                newArmy.Add(child.GetComponent<UnitIcon>().unitPO);
            }
            else
            {
                newCourtyardUnits.Add(child.GetComponent<UnitIcon>().unitPO);
            }

        }

        foreach (Transform child in armyGrid)
        {
            marked = child.GetComponent<UnitIcon>().arrowUpImage.gameObject.activeSelf;
            if (marked)
            {
                newCourtyardUnits.Add(child.GetComponent<UnitIcon>().unitPO);
            }
            else
            {
                newArmy.Add(child.GetComponent<UnitIcon>().unitPO);
            }
        }

        courtyardUnits = newCourtyardUnits;
        army = newArmy;

        GameSaveManager.Save(courtyardUnits, DataType.CourtyardUnitsData);
        GameSaveManager.Save(army, DataType.ArmyData);

        PopulateUnitList();
        FilterItemsBySelection(unitCourtyardGrid);
        FilterItemsBySelection(armyGrid);
    }
}
