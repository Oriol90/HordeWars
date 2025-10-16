using System;

public class ArmoryData : IElementDB
{
    public Guid id { get; set; } = Guid.NewGuid();
    public Item item;
    public int quantity;

    public ArmoryData(Item item, int quantity)
    {
        this.item = item;
        this.quantity = quantity;
    }
}