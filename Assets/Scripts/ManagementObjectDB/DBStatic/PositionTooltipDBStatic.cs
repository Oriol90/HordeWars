using System.Collections.Generic;
using UnityEngine;

public static class PositionTooltipDBStatic
{
    private static readonly Dictionary<TooltipType, Vector2> positionTooltip = new Dictionary<TooltipType, Vector2>
    {
        { TooltipType.UnitCourtyard, new Vector2(100, 125) },
        { TooltipType.ItemCourtyard, new Vector2(350, 125) },
        { TooltipType.UnitArmyHexmap, new Vector2(100, 125) },
        { TooltipType.Instructor, new Vector2(100, 125) },
        { TooltipType.ItemArmory, new Vector2(100, 130) }
    };

    public static Vector2 Get(TooltipType tooltipType)
    {
        return positionTooltip[tooltipType];
    }
}
 