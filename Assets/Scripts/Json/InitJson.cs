using UnityEngine;
using Newtonsoft.Json;
using System.Collections.Generic;

public class InitJson : MonoBehaviour
{

    public GameObject archerPrefab;
    public GameObject girlKnightPrefab;

    void Awake()
    {
        HeroData heroData = new HeroData()
        {
            heroeName = "Melyn",
            heroeLevel = 1,
            heroeSkills = null,
            heroPos = new Vector3Int(0, 3, 0)
        };
        GameSaveManager.Save(heroData, DataType.HeroData);

        PlayerData playerData = new PlayerData { playerName = "Oriol", level = 5 };
        GameSaveManager.Save(playerData, DataType.PlayerData);

        List<TokenData> tokenDataList = new List<TokenData>
        {
            new TokenData { tokenName = "Gold", tokenValue = 100 },
            new TokenData { tokenName = "Silver", tokenValue = 50 }
        };
        GameSaveManager.Save(tokenDataList, DataType.TokenData);

        /*PLANTILLA
        UnitType.LeafArcher,
        new BaseStats{
                life = new int[5] {, , , , },
                attack = new int[5] {, , , ,  },
                attackSpeed = new float[5] {f, f, f, f, f},
                defense = new int[5] {, , , , },
                darkResist = new int[5] {, , , , },
                moveSpeed = new int[5] {, , , , },
                boneCost = ,
                lightCost = ,
                faith = 
            },*/

        Dictionary<UnitType, BaseStats> dictBaseStats = new Dictionary<UnitType, BaseStats>
        {
            {
                UnitType.LeafArcher,
                new BaseStats {
                    life = new int[5] {300, 400, 500, 600, 700},
                    attack = new int[5] {150, 160, 170, 180, 200 },
                    attackSpeed = new float[5] {0.60f, 0.60f, 0.70f, 0.70f, 0.80f},
                    defense = new int[5] {10, 10, 12, 15, 20},
                    darkResist = new int[5] {15, 15, 15, 15, 15},
                    moveSpeed = new float[5] {2f, 2f, 2f, 2f, 2f},
                    boneCost = 25,
                    lightCost = 0,
                    faith = 5
                }
            },
            {
                UnitType.Archer,
                new BaseStats {
                    life = new int[5] {300, 400, 500, 600, 700},
                    attack = new int[5] {150, 160, 170, 180, 200 },
                    attackSpeed = new float[5] {0.60f, 0.60f, 0.70f, 0.70f, 0.80f},
                    defense = new int[5] {10, 10, 12, 15, 20},
                    darkResist = new int[5] {15, 15, 15, 15, 15},
                    moveSpeed = new float[5] {2f, 2f, 2f, 2f, 2f},
                    boneCost = 25,
                    lightCost = 0,
                    faith = 5
                }
            },
            {
                UnitType.GirlKnight,
                new BaseStats {
                    life = new int[5] {700, 750, 800, 850, 900},
                    attack = new int[5] {130, 130, 135, 140, 150},
                    attackSpeed = new float[5] {0.50f, 0.50f, 0.50f, 0.50f, 0.50f},
                    defense = new int[5] {60, 60, 60, 60, 70},
                    darkResist = new int[5] {25, 25, 25, 25, 25},
                    moveSpeed = new float[5] {1.8f, 1.8f, 1.8f, 1.85f, 1.9f},
                    boneCost = 70,
                    lightCost = 0,
                    faith = 15
                }
            }
        };
        GameSaveManager.Save(dictBaseStats, DataType.BaseStats);

        List<UnitData> army = new List<UnitData>
        {
            new UnitData(Race.Human, 4.8f, UnitType.LeafArcher),
            new UnitData(Race.Human, 1f, UnitType.GirlKnight),
            new UnitData(Race.Human, 2.4f, UnitType.GirlKnight),
            new UnitData(Race.Human, 5f, UnitType.GirlKnight),
            new UnitData(Race.Human, 3.1f, UnitType.LeafArcher),
            new UnitData(Race.Human, 2.9f, UnitType.LeafArcher),
            new UnitData(Race.Human, 4.1f, UnitType.LeafArcher),
            new UnitData(Race.Human, 2f, UnitType.LeafArcher),
            new UnitData(Race.Human, 3f, UnitType.LeafArcher),
            new UnitData(Race.Human, 3.5f, UnitType.LeafArcher),
            new UnitData(Race.Human, 5f, UnitType.LeafArcher),
            new UnitData(Race.Human, 2f, UnitType.LeafArcher),
            new UnitData(Race.Human, 1f, UnitType.LeafArcher),
            new UnitData(Race.Human, 3.4f, UnitType.LeafArcher),
            new UnitData(Race.Human, 4.8f, UnitType.LeafArcher),
            new UnitData(Race.Human, 1f, UnitType.GirlKnight),
            new UnitData(Race.Human, 2.4f, UnitType.GirlKnight),
            new UnitData(Race.Human, 5f, UnitType.GirlKnight),
            new UnitData(Race.Human, 3.1f, UnitType.LeafArcher),
            new UnitData(Race.Human, 2.9f, UnitType.LeafArcher),
            new UnitData(Race.Human, 4.1f, UnitType.LeafArcher),
            new UnitData(Race.Human, 2f, UnitType.LeafArcher),
            new UnitData(Race.Human, 3f, UnitType.LeafArcher),
            new UnitData(Race.Human, 3.5f, UnitType.LeafArcher),
            new UnitData(Race.Human, 5f, UnitType.LeafArcher),
            new UnitData(Race.Human, 2f, UnitType.LeafArcher),
            new UnitData(Race.Human, 1f, UnitType.LeafArcher),
            new UnitData(Race.Human, 3.4f, UnitType.LeafArcher),
            new UnitData(Race.Human, 4.8f, UnitType.LeafArcher),
            new UnitData(Race.Human, 1f, UnitType.GirlKnight),
            new UnitData(Race.Human, 2.4f, UnitType.GirlKnight),
            new UnitData(Race.Human, 5f, UnitType.GirlKnight),
            new UnitData(Race.Human, 3.1f, UnitType.LeafArcher),
            new UnitData(Race.Human, 2.9f, UnitType.LeafArcher),
            new UnitData(Race.Human, 4.1f, UnitType.LeafArcher),
            new UnitData(Race.Human, 2f, UnitType.LeafArcher),
            new UnitData(Race.Human, 3f, UnitType.LeafArcher),
            new UnitData(Race.Human, 3.5f, UnitType.LeafArcher),
            new UnitData(Race.Human, 5f, UnitType.LeafArcher),
            new UnitData(Race.Human, 2f, UnitType.LeafArcher),
            new UnitData(Race.Human, 1f, UnitType.LeafArcher),
            new UnitData(Race.Human, 3.4f, UnitType.LeafArcher),
            new UnitData(Race.Human, 4.8f, UnitType.LeafArcher),
            new UnitData(Race.Human, 1f, UnitType.GirlKnight),
            new UnitData(Race.Human, 2.4f, UnitType.GirlKnight),
            new UnitData(Race.Human, 5f, UnitType.GirlKnight),
            new UnitData(Race.Human, 3.1f, UnitType.LeafArcher),
            new UnitData(Race.Human, 2.9f, UnitType.LeafArcher),
            new UnitData(Race.Human, 4.1f, UnitType.LeafArcher),
            new UnitData(Race.Human, 2f, UnitType.LeafArcher),
            new UnitData(Race.Human, 3f, UnitType.LeafArcher),
            new UnitData(Race.Human, 3.5f, UnitType.LeafArcher),
            new UnitData(Race.Human, 5f, UnitType.LeafArcher),
            new UnitData(Race.Human, 2f, UnitType.LeafArcher),
            new UnitData(Race.Human, 1f, UnitType.LeafArcher),
            new UnitData(Race.Human, 3.4f, UnitType.LeafArcher),
            new UnitData(Race.Human, 4.8f, UnitType.LeafArcher),
            new UnitData(Race.Human, 1f, UnitType.GirlKnight),
            new UnitData(Race.Human, 2.4f, UnitType.GirlKnight),
            new UnitData(Race.Human, 5f, UnitType.GirlKnight),
            new UnitData(Race.Human, 3.1f, UnitType.LeafArcher),
            new UnitData(Race.Human, 2.9f, UnitType.LeafArcher),
            new UnitData(Race.Human, 4.1f, UnitType.LeafArcher),
            new UnitData(Race.Human, 2f, UnitType.LeafArcher),
            new UnitData(Race.Human, 3f, UnitType.LeafArcher),
            new UnitData(Race.Human, 3.5f, UnitType.LeafArcher),
            new UnitData(Race.Human, 5f, UnitType.LeafArcher),
            new UnitData(Race.Human, 2f, UnitType.LeafArcher),
            new UnitData(Race.Human, 1f, UnitType.LeafArcher),
            new UnitData(Race.Human, 3.4f, UnitType.LeafArcher),
            new UnitData(Race.Human, 4.8f, UnitType.LeafArcher),
            new UnitData(Race.Human, 1f, UnitType.GirlKnight),
            new UnitData(Race.Human, 2.4f, UnitType.GirlKnight),
            new UnitData(Race.Human, 5f, UnitType.GirlKnight),
            new UnitData(Race.Human, 3.1f, UnitType.LeafArcher),
            new UnitData(Race.Human, 2.9f, UnitType.LeafArcher),
            new UnitData(Race.Human, 4.1f, UnitType.LeafArcher),
            new UnitData(Race.Human, 2f, UnitType.LeafArcher),
            new UnitData(Race.Human, 3f, UnitType.LeafArcher),
            new UnitData(Race.Human, 3.5f, UnitType.LeafArcher),
            new UnitData(Race.Human, 5f, UnitType.LeafArcher),
            new UnitData(Race.Human, 2f, UnitType.LeafArcher),
            new UnitData(Race.Human, 1f, UnitType.LeafArcher),
            new UnitData(Race.Human, 3.4f, UnitType.LeafArcher),
            new UnitData(Race.Human, 4.8f, UnitType.LeafArcher),
            new UnitData(Race.Human, 1f, UnitType.GirlKnight),
            new UnitData(Race.Human, 2.4f, UnitType.GirlKnight),
            new UnitData(Race.Human, 5f, UnitType.GirlKnight),
            new UnitData(Race.Human, 3.1f, UnitType.LeafArcher),
            new UnitData(Race.Human, 2.9f, UnitType.LeafArcher),
            new UnitData(Race.Human, 4.1f, UnitType.LeafArcher),
            new UnitData(Race.Human, 2f, UnitType.LeafArcher),
            new UnitData(Race.Human, 3f, UnitType.LeafArcher),
            new UnitData(Race.Human, 3.5f, UnitType.LeafArcher),
            new UnitData(Race.Human, 5f, UnitType.LeafArcher),
            new UnitData(Race.Human, 2f, UnitType.LeafArcher),
            new UnitData(Race.Human, 1f, UnitType.LeafArcher),
            new UnitData(Race.Human, 3.4f, UnitType.LeafArcher),
            new UnitData(Race.Human, 4.8f, UnitType.LeafArcher),
            new UnitData(Race.Human, 2.1f, UnitType.LeafArcher)
        };
        GameSaveManager.Save(army, DataType.ArmyData);
        List<TalentData> talentList = new List<TalentData>
        {
            new TalentData {
                name = GC.TALENT_CASTLE,
                description = "Increase castle defense",
                enabled = false,
                locked = true,
                require1 = GC.TALENT_CROWN
            },
            new TalentData {
                name = GC.TALENT_CAULDRON,
                description = "Now can use the cauldron",
                enabled = false,
                locked = true,
                require1 = GC.TALENT_MORTAR_AND_PESTLE
            },
            new TalentData {
                name = GC.TALENT_CROWN,
                description = "You're the king",
                enabled = false,
                locked = true,
                require1 = GC.TALENT_CRYSTALS,
                require2 = GC.TALENT_WAND
            },
            new TalentData {
                name = GC.TALENT_CRYSTAL_1,
                description = "You can now embed gems level 1",
                enabled = false,
                locked = false,
            },
            new TalentData {
                name = GC.TALENT_CRYSTAL_2,
                description = "You can now embed gems level 2",
                enabled = false,
                locked = true,
                require1 = GC.TALENT_CRYSTAL_1
            },
            new TalentData {
                name = GC.TALENT_CRYSTAL_ORB,
                description = "Now you can see the future",
                enabled = false,
                locked = true,
                require1 = GC.TALENT_MAGIC_HAT
            },
            new TalentData {
                name = GC.TALENT_CRYSTALS,
                description = "Now you can embed multiple gems",
                enabled = false,
                locked = true,
                require1 = GC.TALENT_CRYSTAL_2
            },
            new TalentData {
                name = GC.TALENT_MAGIC_ESSENCE,
                description = "You can use medium spells",
                enabled = false,
                locked = false,
            },
            new TalentData {
                name = GC.TALENT_MAGIC_HAT,
                description = "You can use basic spells",
                enabled = false,
                locked = false,
            },
            new TalentData {
                name = GC.TALENT_MORTAR_AND_PESTLE,
                description = "You can combine ingredients",
                enabled = false,
                locked = false,
            },
            new TalentData {
                name = GC.TALENT_POTION_1,
                description = "You can make healing potions",
                enabled = false,
                locked = true,
                require1 = GC.TALENT_CAULDRON
            },
            new TalentData {
                name = GC.TALENT_POTION_2,
                description = "You can make mana potions",
                enabled = false,
                locked = true,
                require1 = GC.TALENT_CAULDRON
            },
            new TalentData {
                name = GC.TALENT_SPELLBOOK,
                description = "You can use advanced spells",
                enabled = false,
                locked = true,
                require1 = GC.TALENT_MAGIC_ESSENCE
            },
            new TalentData {
                name = GC.TALENT_SWORDS,
                description = "Increase castle attack",
                enabled = false,
                locked = true,
                require1 = GC.TALENT_CASTLE
            },
            new TalentData {
                name = GC.TALENT_WAND,
                description = "You can use the wand",
                enabled = false,
                locked = true,
                require1 = GC.TALENT_SPELLBOOK
            },
        };
        GameSaveManager.Save(talentList, DataType.TalentData);
    }
    
    // void AddUnit(GameObject prefab, float exp, UnitType unitType)
    // {
    //     GameObject go = Instantiate(prefab);
    //     Unit unit = Utils.UnitTypeToUnit(unitType, go);
    //     unit.SetExp(exp);
    //     army.Add(unit);
    // }

}