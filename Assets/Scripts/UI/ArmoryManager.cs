using UnityEngine;
using TMPro;
using System;
using System.Collections.Generic;

public class Armory : MonoBehaviour
{
    [Header("Dropdowns")]
    public TMP_Dropdown rarityDropdown;
    public TMP_Dropdown unitTypeDropdown;

    [Header("GO itemIcon")]
    public GameObject itemIconPrefab;
    public Transform itemGrid;

    private Rarity selectedRarity;
    private UnitType selectedUnit;


    private void Start()
    {
        PopulateDropdowns();
        PopulateItemList();
    }

    private void PopulateDropdowns()
    {

        List<string> rarityOptions = new(Enum.GetNames(typeof(Rarity)));
        List<string> unitOptions = new(Enum.GetNames(typeof(UnitType)));

        // --- RAREZA ---
        rarityDropdown.ClearOptions();
        rarityOptions.Insert(0, "All");
        rarityDropdown.AddOptions(rarityOptions);

        // --- TIPO DE UNIDAD ---
        unitTypeDropdown.ClearOptions();
        unitOptions.Insert(0, "All");
        unitTypeDropdown.AddOptions(unitOptions);

        rarityDropdown.value = 0;
        unitTypeDropdown.value = 0;

        rarityDropdown.onValueChanged.AddListener(OnRarityChanged);
        unitTypeDropdown.onValueChanged.AddListener(OnUnitTypeChanged);
    }

    private void OnRarityChanged(int index)
    {
        GC.ARMORY_SELECTED_RARITY = index;
        PopulateItemList();
    }

    private void OnUnitTypeChanged(int index)
    {
        GC.ARMORY_SELECTED_UNIT = index;
        PopulateItemList();
    }

    private void PopulateItemList()
    {
        foreach (Transform child in itemGrid)
        {
            Destroy(child.gameObject);
        }
        ItemTooltip.Instance.ClearTooltip();

        Dictionary<Item, int> itemQuantityDict = GameSaveManager.Load<Dictionary<Item, int>>(DataType.ArmoryData);
        Dictionary<Item, ItemData> itemDataDict = new(GameSaveManager.Load<Dictionary<Item, ItemData>>(DataType.ItemData));
        Dictionary<Item, int> filteredDict = FilterItemsBySelection(itemQuantityDict, itemDataDict);


        foreach (var item in filteredDict)
        {
            CreateUnitEntry(item.Key, item.Value, itemDataDict);
        }
    }

    private void CreateUnitEntry(Item item, int quantity, Dictionary<Item, ItemData> itemDataDict)
    {
        GameObject itemIconGO = Instantiate(itemIconPrefab, itemGrid);
        ItemIcon itemIcon = itemIconGO.GetComponent<ItemIcon>();

        itemIcon.SetUp(itemDataDict[item], quantity);
    }

    private Dictionary<Item, int> FilterItemsBySelection(Dictionary<Item, int> itemQuantityDict, Dictionary<Item, ItemData> itemDataDict)
    {
        Dictionary<Item, int> filteredDict = new();

        foreach (var item in itemQuantityDict)
        {
            if ((GC.ARMORY_SELECTED_RARITY == 0 || itemDataDict[item.Key].Rarity == (Rarity)(GC.ARMORY_SELECTED_RARITY - 1)) &&
                (GC.ARMORY_SELECTED_UNIT == 0 || itemDataDict[item.Key].UnitType == (UnitType)(GC.ARMORY_SELECTED_UNIT - 1)))
            {
                filteredDict[item.Key] = item.Value;
            }
        }
        return filteredDict;
    }
}
