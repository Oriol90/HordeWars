using System.Collections.Generic;

public static class InitJson
{
    public static void Init()
    {
        // InitBaseStats();
        // InitArmy(50);
        // InitHero();
        // InitPlayerData();
        // InitTokenData();
        // InitTalents();
        // InitInstructorData(50);
        // InitArmory();
        // InitCourtyardUnits(50);
    }

    private static void InitHero()
    {
        HeroData heroData = new HeroData()
        {
            heroeName = "Melyn",
            heroeLevel = 1,
            heroeSkills = null,
            //ARREGLAR heroPos = new Vector2(0, 3, 0)
        };
        GameSaveManager.Save(heroData, DataType.HeroData);
        
    }

    private static void InitTokenData() {
        Dictionary<Token, int> tokenDict = new Dictionary<Token, int>
        {
            { Token.Bones, 500 },
            { Token.CurrentTime, 0 },
            { Token.Gold, 1000 }
            
        };
        GameSaveManager.Save(tokenDict, DataType.TokenData);
    }

    private static void InitInstructorData(int numInstructors) {

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

    private static void InitArmory()
    {
        Dictionary<Item, int> armory = new Dictionary<Item, int>
        {
            { Item.WoodenSword, 50 },
            { Item.IronShield, 30 },
            { Item.MagicWand, 5 },
            { Item.Bow, 7 },
            { Item.Staff, 4 },
            { Item.Ring, 2 }
        };
        GameSaveManager.Save(armory, DataType.ArmoryData);
    }

     private static void InitCourtyardUnits(int numUnits)
    {
        List<object> courtyardUnits = new List<object>();
        for(int i = 0; i < numUnits; i++){
            courtyardUnits.Add(UnitFactory.CreateRandomUnitData());           
        };
        Collections.GetList(DataType.CourtyardUnitsData).AddList(courtyardUnits);
    }

    private static void InitArmy(int numUnits)
    {
        List<object> army = new List<object>();
        for(int i = 0; i < numUnits; i++){
            army.Add(UnitFactory.CreateRandomUnitData());
        };
        Collections.GetList(DataType.ArmyData).AddList(army);
    }

    private static void InitTalents() {
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
