using System;
using System.Collections.Generic;

[System.Serializable]
public class GameData{
    public PlayerData playerData;
    public HeroeData heroeData;
    public List<TokenData> tokenData;
    public List<ArmyData> armyData;
    public List<Talent> talents;
    
    public GameData(){
        playerData = new PlayerData();
        armyData = new List<ArmyData>();
        heroeData = new HeroeData();
        talents = new List<Talent>();
        tokenData = new List<TokenData>();
    }
}

public class PlayerData {
    public string playerName;
    public int level;
}

public class HeroeData {
    public string heroeName;
    public int heroeLevel;
    public List<int> heroeSkills;
}

public class ArmyData{
    public string unitType;
    public int quantity;
}

public class TokenData
{
    public string tokenName;
    public int tokenValue;
}

public class Talent
{
    public string name;
    public string description;
    public Boolean enabled { get; set; }
    public Boolean locked { get; set; }
    public String require1;
    public String require2;

    
}


