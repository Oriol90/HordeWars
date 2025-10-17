using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;

public static class GC
{
    //Directorio de guardado
    public const string SAVE_DIRECTORY = "Saves";
    public const string SAVE_FILE_NAME = "steamId_save.json";
    public const string MAP_DIRECTORY = "Maps";
    public const string MAP_FILE_NAME = "Map";
    public const string FOG_MAP_FILE_NAME = "FogMap";

    //Scenes
    public const string SCENE_MAIN_MENU = "MainMenu Scene";
    public const string SCENE_TALENT_TREE = "TalentTree Scene";
    public const string SCENE_BATTLEGROUND = "BattleGround Scene";
    public const string SCENE_HEROE_SELECTION = "HeroeSelection Scene";
    public const string SCENE_RACE_SELECTION = "RaceSelection Scene";
    public const string SCENE_MAP = "Map Scene";
    public const string SCENE_HEX_MAP = "HexMap Scene";
    public const string SCENE_CAMP = "Camp Scene";

    // Tamaño de la cuadrícula
    public const float CELL_SIZE = 0.5f;

    //Tamaño tileMap
    public const int TILEMAP_X_MIN = -100;
    public const int TILEMAP_Y_MIN = -100;
    public const int TILEMAP_X_MAX = 100;
    public const int TILEMAP_Y_MAX = 100;

    //Velocidad del juego
    public const float TIME_SPEED = 0.2f;

    //Limite de unidades del heroe
    public const int HERO_UNIT_LIMIT = 50;

    // Valores del mapa (73,41)
    public const int MapWidth = 73;
    public const int MapHeight = 41;
    public const float MAP_HEIGHT = 18f;
    public const float MAP_BOT = -9f;

    //Enemigo, aliado o lo que sea
    public const string ENEMY = "Enemy";
    public const string ALLY = "Ally";

    //Mapa battleGround
    public static CellTracker[,] MapPositions = new CellTracker[MapWidth, MapHeight];

    //ArmyUnits
    public static Dictionary<String, int> ARMY_UNITS;

    //Animations
    public const string ANIM_ATTACK = "isAttacking";
    public const string ANIM_WALK = "isWalking";
    public const string ANIM_IDLE = "isIdle";
    public const string ANIM_DEAD = "isDead";

    //Races
    public const string RACE_ORC = "ORC";
    public const string RACE_ELF = "ELF";
    public const string RACE_HUMAN = "HUMAN";
    public const string RACE_UNDEAD = "UNDEAD";

    // --- Unidades --- \\
    //Humanos
    public const string UNIT_GIRL_KNIGHT = "girlKnight";
    public const int GIRL_KNIGHT_INITIAL_ZONE_X = -10;
    public const int GIRL_KNIGHT_INITIAL_WIDTH = 8;
    public static float TIME_INTERVAL_GIRL_KNIGHT = 1.5f;

    //Undead
    public const string UNIT_LEAF_ARCHER = "leafArcher";
    public const int LEAF_ARCHER_INITIAL_ZONE_X = 2;
    public const int LEAF_ARCHER_INITIAL_WIDTH = 8;
    public static float TIME_INTERVAL_LEAF_ARCHER = 0.5f;


    //PlayerPrefs
    public const string PLAYER_PREFS_SELECTED_RACE = "SelectedRace";

    //Ejercito Inicial
    public static Dictionary<string, int> INITIAL_ARMY_1 = new()
    {
            { UNIT_GIRL_KNIGHT, 5 },
            { UNIT_LEAF_ARCHER, 3 }
        };

    public static Dictionary<string, int> INITIAL_ARMY_2 = new()
        {
            { UNIT_GIRL_KNIGHT, 12 },
            { UNIT_LEAF_ARCHER, 0 }
        };

    public static Dictionary<string, int> INITIAL_ARMY_3 = new()
        {
            { UNIT_GIRL_KNIGHT, 8 },
            { UNIT_LEAF_ARCHER, 6 }
        };

    //Nombre talentos
    public const string TALENT_CASTLE = "castle";
    public const string TALENT_CAULDRON = "cauldron";
    public const string TALENT_CROWN = "crown";
    public const string TALENT_CRYSTAL_1 = "crystal_1";
    public const string TALENT_CRYSTAL_2 = "crystal_2";
    public const string TALENT_CRYSTAL_ORB = "crystal_orb";
    public const string TALENT_CRYSTALS = "crystals";
    public const string TALENT_MAGIC_ESSENCE = "magic_essence";
    public const string TALENT_MAGIC_HAT = "magic_hat";
    public const string TALENT_MORTAR_AND_PESTLE = "mortar_and_pestle";
    public const string TALENT_POTION_1 = "potion_1";
    public const string TALENT_POTION_2 = "potion_2";
    public const string TALENT_SPELLBOOK = "spellbook";
    public const string TALENT_SWORDS = "swords";
    public const string TALENT_WAND = "wand";

    //Fog tiles
    public const string FOG_TILE_NAME = "Niebla";
    public const string SHADOW_TILE_NAME = "Sombra";

    //Selected options armory
    public static int ARMORY_SELECTED_RARITY = 0;
    public static int ARMORY_SELECTED_UNIT = 0;

    //Selected options courtyard
    public static int COURTYARD_SELECTED_RARITY = 0;    
    public static int COURTYARD_SELECTED_UNIT = 0;
    public static int COURTYARD_SELECTED_LEVEL = 0;

    //Experience required for each level
    public static int EXPERIENCE_REQ_LEVEL_2 = 100;
    public static int EXPERIENCE_REQ_LEVEL_3 = 300;
    public static int EXPERIENCE_REQ_LEVEL_4 = 600;
    public static int EXPERIENCE_REQ_LEVEL_5 = 1000;
    public static int EXPERIENCE_REQ_LEVEL_6 = 1500;

    //Actions
    public static List<TokenData> GET_TOKEN_DATA_LIST { get { return ((TokenDataList)Collections.GetList(DataType.TokenData)).objects.ToList(); }}
    public static List<UnitData> GET_ARMY_LIST { get { return ((ArmyDataList)Collections.GetList(DataType.ArmyData)).objects.ToList(); }}
    public static List<UnitData> GET_COURTYARD_UNIT_LIST { get { return ((CourtyardUnitDataList)Collections.GetList(DataType.CourtyardUnitsData)).objects.ToList(); }}
    public static List<InstructorData> GET_INSTRUCTOR_LIST { get { return ((InstructorDataList)Collections.GetList(DataType.InstructorData)).objects.ToList(); }}
    public static List<TrainingUnitData> GET_TRAINING_UNIT_LIST { get { return ((TrainingUnitDataList)Collections.GetList(DataType.TrainingUnitData)).objects.ToList(); }}
    public static List<ScheduledEventData> GET_SCHEDULED_EVENT_LIST { get { return ((ScheduledEventDataList)Collections.GetList(DataType.ScheduledEventData)).objects.ToList(); }}
    public static List<ArmoryData> GET_ARMORY_DATA_LIST { get { return ((ArmoryDataList)Collections.GetList(DataType.ArmoryData)).objects.ToList(); }}
}