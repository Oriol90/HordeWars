using System;

[Serializable]
public class StatsInstructor
{
    public int health;
    public int attack;
    public int attackSpeed;
    public int defense;
    public int darkResist;
    public int moveSpeed;
    public int faith;
    
    public StatsInstructor(int health, int attack, int attackSpeed, int defense, int darkResist, int moveSpeed, int faith)
    {
        this.health = health;
        this.attack = attack;
        this.attackSpeed = attackSpeed;
        this.defense = defense;
        this.darkResist = darkResist;
        this.moveSpeed = moveSpeed;
        this.faith = faith;
    }
}