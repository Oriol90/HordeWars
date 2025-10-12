using UnityEngine;

public class TooltipObj
{
    public string title;
    public string body;
    public Vector2 finalPosition;

    public TooltipObj(string title, string body, TooltipType tooltipType, Vector2 position)
    {
        this.title = title;
        this.body = body;
        finalPosition = PositionTooltipDBStatic.Get(tooltipType) + position;
    }
}