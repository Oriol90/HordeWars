using UnityEngine;
using System.Collections.Generic;

public class InitJson : MonoBehaviour
{
    void Awake()
    {
        // InitBaseStats();
        // InitArmy(50);
        // InitHero();
        // InitPlayerData();
        // InitTokenData();
        // InitTalents();
        InitInstructorData(50);
        // InitArmory();
        // InitCourtyardUnits(50);
    }

    private void InitHero()
    {
        HeroData heroData = new HeroData()
        {
            heroeName = "Melyn",
            heroeLevel = 1,
            heroeSkills = null,
            heroPos = new Vector3Int(0, 3, 0)
        };
        GameSaveManager.Save(heroData, DataType.HeroData);
        
    }

    private void InitTokenData() {
        Dictionary<Token, int> tokenDict = new Dictionary<Token, int>
        {
            { Token.Bones, 500 },
            { Token.CurrentTime, 0 },
            { Token.Gold, 1000 }
            
        };
        GameSaveManager.Save(tokenDict, DataType.TokenData);
    }

    private void InitInstructorData(int numInstructors) {

        List<InstructorData> instructorList = new List<InstructorData>();

        for(int i = 0; i < numInstructors; i++)
        {
            Gender gender = Utils.GetRandomEnumValue<Gender>();
            Rarity rarity = Utils.GetRandomEnumValue<Rarity>();
            UnitType trainableUnit = Utils.GetRandomEnumValue<UnitType>();
            
            List<Mastery> masteries = new List<Mastery>();
            for (int k = 0; k < Utils.CreateRandomNumber(1, 3); k++) {
                Mastery mastery = Utils.GetRandomEnumValue<Mastery>();
                if (!masteries.Contains(mastery)) {
                    masteries.Add(mastery);
                }
            }

            int trainingCost = Utils.CreateRandomNumber(15, 90);
            int trainingTime = Utils.CreateRandomNumber(8, 72);

            instructorList.Add(new InstructorData(NamesDBStatic.GetRandomNameByGender(gender), gender, trainableUnit, rarity, masteries, trainingCost, trainingTime, ResourcePathDBStatic.GetRandomInstructorPath(gender)));
        };

        GameSaveManager.Save(instructorList, DataType.InstructorData);
    }

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

    private void InitBaseStats()
    {
        Dictionary<UnitType, BaseStats> dictBaseStats = new Dictionary<UnitType, BaseStats>
        {
            {
                UnitType.LeafArcher,
                new BaseStats {
                    health = new int[6] {300, 400, 500, 600, 700, 800},
                    attack = new int[6] {150, 160, 170, 180, 200, 220 },
                    attackSpeed = new float[6] {0.60f, 0.60f, 0.70f, 0.70f, 0.80f, 0.80f},
                    defense = new int[6] {10, 10, 12, 15, 20, 25},
                    darkResist = new int[6] {15, 15, 15, 15, 15, 15},
                    moveSpeed = new float[6] {2f, 2f, 2f, 2f, 2f, 2f},
                    boneCost = 25,
                    lightCost = 0,
                    faith = 5
                }
            },
            {
                UnitType.Archer,
                new BaseStats {
                    health = new int[6] {300, 400, 500, 600, 700, 800},
                    attack = new int[6] {150, 160, 170, 180, 200, 220},
                    attackSpeed = new float[6] {0.60f, 0.60f, 0.70f, 0.70f, 0.80f, 0.80f},
                    defense = new int[6] {10, 10, 12, 15, 20, 25},
                    darkResist = new int[6] {15, 15, 15, 15, 15, 15},
                    moveSpeed = new float[6] {2f, 2f, 2f, 2f, 2f, 2f},
                    boneCost = 25,
                    lightCost = 0,
                    faith = 5
                }
            },
            {
                UnitType.GirlKnight,
                new BaseStats {
                    health = new int[6] {700, 750, 800, 850, 900, 950},
                    attack = new int[6] {130, 130, 135, 140, 150, 160},
                    attackSpeed = new float[6] {0.50f, 0.50f, 0.50f, 0.50f, 0.50f, 0.50f},
                    defense = new int[6] {60, 60, 60, 60, 70, 80},
                    darkResist = new int[6] {25, 25, 25, 25, 25, 25},
                    moveSpeed = new float[6] {1.8f, 1.8f, 1.8f, 1.85f, 1.9f, 1.95f},
                    boneCost = 70,
                    lightCost = 0,
                    faith = 15
                }
            },
            {
                UnitType.Felipe,
                new BaseStats {
                    health = new int[6] {1000, 1100, 1200, 1300, 1400, 1500},
                    attack = new int[6] {200, 220, 240, 260, 280, 300},
                    attackSpeed = new float[6] {1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f},
                    defense = new int[6] {80, 85, 90, 95, 100, 110},
                    darkResist = new int[6] {30, 30, 30, 30, 30, 30},
                    moveSpeed = new float[6] {1.5f, 1.5f, 1.5f, 1.5f, 1.5f, 1.5f},
                    boneCost = 150,
                    lightCost = 0,
                    faith = 50
                }
            }
        };
        GameSaveManager.Save(dictBaseStats, DataType.BaseStats);
    }

    private void InitArmory()
    {
        Dictionary<Item, int> armory = new Dictionary<Item, int>
        {
            { Item.WoodenSword, 50 },
            { Item.IronShield, 30 },
            { Item.MagicWand, 5 },
            { Item.Bow, 7 },
            { Item.Staff, 4 },
            { Item.Ring, 2 },
        };
        GameSaveManager.Save(armory, DataType.ArmoryData);
    }

     private void InitCourtyardUnits(int numUnits)
    {
        List<UnitData> courtyardUnits = new List<UnitData>();

        for(int i = 0; i < numUnits; i++){
            UnitType unitType = Utils.GetRandomEnumValue<UnitType>();
            courtyardUnits.Add(new UnitData(NamesDBStatic.GetRandomNameByUnitType(unitType), Race.Human, Utils.CreateRandomNumber(0, 2000), unitType, Utils.GetRandomEnumValue<Item>()));           
        };
        GameSaveManager.Save(courtyardUnits, DataType.CourtyardUnitsData);
    }

    private void InitArmy(int numUnits)
    {
        List<UnitData> army = new List<UnitData>();

        for(int i = 0; i < numUnits; i++){
            UnitType unitType = Utils.GetRandomEnumValue<UnitType>();
            army.Add(new UnitData(NamesDBStatic.GetRandomNameByUnitType(unitType), Race.Human, Utils.CreateRandomNumber(0, 2000), unitType, Utils.GetRandomEnumValue<Item>()));           
        };
        GameSaveManager.Save(army, DataType.ArmyData);
    }

    private void InitTalents() {
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
}
