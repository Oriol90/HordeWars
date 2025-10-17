using UnityEngine;
using TMPro;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using System.Collections.ObjectModel;

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

    [Header("Buttons")]
    public Button switchUnitsButton;
    public Button autoSwitchButton;

    private void Start()
    {
        InitJson.Init();
        PopulateDropdowns();
        PopulateUnitList();
        SetUpButtons();
    }

    private void SetUpButtons()
    {
        switchUnitsButton.onClick.AddListener(() => SwitchUnits());
        autoSwitchButton.onClick.AddListener(() => AutoSwitchUnits());

        switchUnitsButton.GetComponentInChildren<TextMeshProUGUI>().text = LocalizationManager.GetText(TextKeys.SWITCH_UNITS);
        autoSwitchButton.GetComponentInChildren<TextMeshProUGUI>().text = LocalizationManager.GetText(TextKeys.AUTO_SWITCH);
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

        foreach (var unit in GC.GET_COURTYARD_UNIT_LIST.ToList().
                OrderByDescending(x => x.level).
                ThenByDescending(x => Utils.RarityToNum(ItemDBStatic.Get(x.equippedItem).Rarity)))
        {
            CreateCourtyardUnitEntry(unit);
        }

        foreach (var unit in GC.GET_ARMY_LIST.ToList().
                OrderByDescending(x => x.level).
                ThenByDescending(x => Utils.RarityToNum(ItemDBStatic.Get(x.equippedItem).Rarity)))
        {
            CreateArmyUnitEntry(unit);
        }
    }

    private void CreateCourtyardUnitEntry(UnitData unit)
    {
        GameObject unitIconGO = Instantiate(unitIconPrefab, unitCourtyardGrid);
        UnitIcon unitIcon = unitIconGO.GetComponent<UnitIcon>();

        unitIcon.SetUp(unit, true);
    }

    private void CreateArmyUnitEntry(UnitData unit)
    {
        GameObject unitIconGO = Instantiate(unitIconPrefab, armyGrid);
        UnitIcon unitIcon = unitIconGO.GetComponent<UnitIcon>();

        unitIcon.SetUp(unit, false);
    }

    private void FilterItemsBySelection(Transform grid)
    {

        foreach (Transform child in grid)
        {
            UnitData unit = child.GetComponent<UnitIcon>().unitData;
            ItemData itemData = ItemDBStatic.Get(unit.equippedItem);
            if ((GC.COURTYARD_SELECTED_RARITY == 0 || itemData.Rarity == (Rarity)(GC.COURTYARD_SELECTED_RARITY - 1)) &&
                (GC.COURTYARD_SELECTED_UNIT == 0 || unit.unitType == (UnitType)(GC.COURTYARD_SELECTED_UNIT - 1)) &&
                (GC.COURTYARD_SELECTED_LEVEL == 0 || unit.level == GC.COURTYARD_SELECTED_LEVEL))
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

        foreach (Transform child in unitCourtyardGrid)
        {
            UnitData unit = child.GetComponent<UnitIcon>().unitData;
            marked = child.GetComponent<UnitIcon>().arrowDownImage.gameObject.activeSelf;
            if (marked)
            {
                Collections.GetList(DataType.CourtyardUnitsData).Delete(unit.id);
                Collections.GetList(DataType.ArmyData).Add(unit);
            }
        }

        foreach (Transform child in armyGrid)
        {
            UnitData unit = child.GetComponent<UnitIcon>().unitData;
            marked = child.GetComponent<UnitIcon>().arrowUpImage.gameObject.activeSelf;

            if (marked)
            {
                Collections.GetList(DataType.ArmyData).Delete(unit.id);
                Collections.GetList(DataType.CourtyardUnitsData).Add(unit);
            }
        }

        PopulateUnitList();
        FilterItemsBySelection(unitCourtyardGrid);
        FilterItemsBySelection(armyGrid);
    }

    private void AutoSwitchUnits()
    {
        List<UnitData> allUnits = GC.GET_COURTYARD_UNIT_LIST.Concat(GC.GET_ARMY_LIST).ToList();
        allUnits = allUnits. OrderByDescending(x => x.avgRarity).ThenBy(x => x.id).ToList();

        List<object> listCourtyardUnits = new List<object>();
        List<object> listArmyUnits = new List<object>();

        for (int i = 0; i < GC.HERO_UNIT_LIMIT; i++)
        {
            listArmyUnits.Add(allUnits[i]);
        }
        for (int i = GC.HERO_UNIT_LIMIT; i < allUnits.Count; i++)
        {
            listCourtyardUnits.Add(allUnits[i]);
        }

        allUnits.Clear();
        Collections.GetList(DataType.CourtyardUnitsData).ReplaceList(listCourtyardUnits);
        Collections.GetList(DataType.ArmyData).ReplaceList(listArmyUnits);
        
        PopulateUnitList();
        FilterItemsBySelection(unitCourtyardGrid);
        FilterItemsBySelection(armyGrid);
    }
}
