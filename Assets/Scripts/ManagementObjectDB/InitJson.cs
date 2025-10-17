using System.Collections.Generic;

public static class InitJson
{
    public static void Init()
    {
        // InitBaseStats();
         InitArmy(500);
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
        List<object> tokenList = new List<object>
        {
            new TokenData(Token.Bones, 500),
            new TokenData(Token.CurrentTime, 0),
            new TokenData(Token.Gold, 1000)
        };
        Collections.GetList(DataType.TokenData).ReplaceList(tokenList);
    }

    private static void InitInstructorData(int numInstructors) {

        List<object> instructorList = new List<object>();

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
        Collections.GetList(DataType.InstructorData).ReplaceList(instructorList);
    }

    private static void InitArmory()
    {
        List<object> armory = new List<object>
        {
            new ArmoryData( Item.WoodenSword, 50 ),
            new ArmoryData( Item.IronShield, 30 ),
            new ArmoryData( Item.MagicWand, 5 ),
            new ArmoryData( Item.Bow, 7 ),
            new ArmoryData( Item.Staff, 4 ),
            new ArmoryData( Item.Ring, 2 )
        };
        Collections.GetList(DataType.ArmoryData).ReplaceList(armory);
    }

     private static void InitCourtyardUnits(int numUnits)
    {
        List<object> courtyardUnits = new List<object>();
        for(int i = 0; i < numUnits; i++){
            courtyardUnits.Add(UnitFactory.CreateRandomUnitData());           
        };
        Collections.GetList(DataType.CourtyardUnitsData).ReplaceList(courtyardUnits);
    }

    private static void InitArmy(int numUnits)
    {
        List<object> army = new List<object>();
        for(int i = 0; i < numUnits; i++){
            army.Add(UnitFactory.CreateRandomUnitData());
        };
        Collections.GetList(DataType.ArmyData).ReplaceList(army);
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
