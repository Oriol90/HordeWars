using UnityEngine;
using Newtonsoft.Json;
using System.Collections.Generic;

public class JsonTest : MonoBehaviour
{
    void Start()
    {
        // Guardar
        GameData gameData = new()
        {
            playerData = new PlayerData { playerName = "Oriol", level = 5 },
            heroeData = new HeroeData { heroeName = "Melyn", heroeLevel = 3, heroeSkills = new List<int> { 1, 0, 2, 1 } },
            tokenData = new List<TokenData>
            {
                new TokenData { tokenName = "Gold", tokenValue = 100 },
                new TokenData { tokenName = "Silver", tokenValue = 50 }
            },
            armyData = new List<ArmyData>
            {
                new ArmyData { unitType = "GirlKnight", quantity = 10 },
                new ArmyData { unitType = "LeafArcher", quantity = 15 }
            },
            talents = new List<Talent>
            {
                new Talent {
                    name = GC.TALENT_CASTLE,
                    description = "Increase castle defense",
                    enabled = false,
                    locked = true,
                    require1 = GC.TALENT_CROWN
                },
                new Talent {
                    name = GC.TALENT_CAULDRON,
                    description = "Now can use the cauldron",
                    enabled = false,
                    locked = true,
                    require1 = GC.TALENT_MORTAR_AND_PESTLE
                },
                new Talent {
                    name = GC.TALENT_CROWN,
                    description = "You're the king",
                    enabled = false,
                    locked = true,
                    require1 = GC.TALENT_CRYSTALS,
                    require2 = GC.TALENT_WAND
                },
                new Talent {
                    name = GC.TALENT_CRYSTAL_1,
                    description = "You can now embed gems level 1",
                    enabled = false,
                    locked = false,
                },
                new Talent {
                    name = GC.TALENT_CRYSTAL_2,
                    description = "You can now embed gems level 2",
                    enabled = false,
                    locked = true,
                    require1 = GC.TALENT_CRYSTAL_1
                },
                new Talent {
                    name = GC.TALENT_CRYSTAL_ORB,
                    description = "Now you can see the future",
                    enabled = false,
                    locked = true,
                    require1 = GC.TALENT_MAGIC_HAT
                },
                new Talent {
                    name = GC.TALENT_CRYSTALS,
                    description = "Now you can embed multiple gems",
                    enabled = false,
                    locked = true,
                    require1 = GC.TALENT_CRYSTAL_2
                },
                new Talent {
                    name = GC.TALENT_MAGIC_ESSENCE,
                    description = "You can use medium spells",
                    enabled = false,
                    locked = false,
                },
                new Talent {
                    name = GC.TALENT_MAGIC_HAT,
                    description = "You can use basic spells",
                    enabled = false,
                    locked = false,
                },
                new Talent {
                    name = GC.TALENT_MORTAR_AND_PESTLE,
                    description = "You can combine ingredients",
                    enabled = false,
                    locked = false,
                },
                new Talent {
                    name = GC.TALENT_POTION_1,
                    description = "You can make healing potions",
                    enabled = false,
                    locked = true,
                    require1 = GC.TALENT_CAULDRON
                },
                new Talent {
                    name = GC.TALENT_POTION_2,
                    description = "You can make mana potions",
                    enabled = false,
                    locked = true,
                    require1 = GC.TALENT_CAULDRON
                },
                new Talent {
                    name = GC.TALENT_SPELLBOOK,
                    description = "You can use advanced spells",
                    enabled = false,
                    locked = true,
                    require1 = GC.TALENT_MAGIC_ESSENCE
                },
                new Talent {
                    name = GC.TALENT_SWORDS,
                    description = "Increase castle attack",
                    enabled = false,
                    locked = true,
                    require1 = GC.TALENT_CASTLE
                },
                new Talent {
                    name = GC.TALENT_WAND,
                    description = "You can use the wand",
                    enabled = false,
                    locked = true,
                    require1 = GC.TALENT_SPELLBOOK
                },
            }
        };
        GameSaveManager.SaveGame(gameData);
    }
}