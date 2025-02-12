using LiteDB;

public class UnitData
{
    [BsonId] public int Id { get; set; }
    public string Name { get; set; }
    public int Health { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public int Speed { get; set; }
    public int Experience { get; set; }
    public int Level { get; set; }
}
