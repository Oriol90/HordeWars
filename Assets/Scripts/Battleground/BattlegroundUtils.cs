using UnityEngine;

public static class BattleGroundUtils
{

public static int CalculateDistance(Vector2Int ownPos, Vector2Int targetPos){
        int ownPosX = ownPos.x;
        int ownPosY = ownPos.y;
        int targetPosX = targetPos.x;
        int targetPosY = targetPos.y;
        int distanceX, distanceY;

        if(ownPosX > targetPosX) distanceX = ownPosX - targetPosX;
        else if(ownPosX < targetPosX) distanceX = targetPosX - ownPosX;
        else distanceX = 0;

        if(ownPosY > targetPosY) distanceY = ownPosY - targetPosY;
        else if(ownPosY < targetPosY) distanceY = targetPosY - ownPosY;
        else distanceY = 0;

        return distanceX + distanceY;
    }

    public static Vector2Int CalcHalfDistance(Vector2Int pos, Vector2Int currentGridPos, string side){
        int x = currentGridPos.x + ((pos.x - currentGridPos.x) / 2);
        int y = currentGridPos.y + ((pos.y - currentGridPos.y) / 2);
        if(side == GC.ENEMY && (pos.x - currentGridPos.x) % 2 == 0 && (pos.x - currentGridPos.x) != 0 && pos.x > currentGridPos.x) x--;
        if(side == GC.ENEMY && (pos.x - currentGridPos.x) % 2 == 0 && (pos.x - currentGridPos.x) != 0 && pos.x < currentGridPos.x) x++;
        if(side == GC.ENEMY && (pos.y - currentGridPos.y) % 2 == 0 && (pos.y - currentGridPos.y) != 0 && pos.y > currentGridPos.y) y--;
        if(side == GC.ENEMY && (pos.y - currentGridPos.y) % 2 == 0 && (pos.y - currentGridPos.y) != 0 && pos.y < currentGridPos.y) y++;
        return new Vector2Int(x, y);
    }

    public static Vector3 GridToWorld(Vector2Int gridPos)
    {
        // Convertir coordenadas de la cuadrícula a posiciones del mundo
        float worldX = (gridPos.x + 0.5f) * GC.CELL_SIZE;
        float worldY = (gridPos.y + 0.5f) * GC.CELL_SIZE;
        return new Vector3(worldX, worldY, 0);
    }

    public static Vector2Int WorldToGrid(Vector3 worldPos)
    {
        // Convertir coordenadas del mundo a posiciones de la cuadrícula
        int gridX = Mathf.FloorToInt(worldPos.x / GC.CELL_SIZE);
        int gridY = Mathf.FloorToInt(worldPos.y / GC.CELL_SIZE);
        return new Vector2Int(gridX, gridY);
    }

    public static bool IsInsideBounds(int x, int y)
    {
        // Asegúrate de que GC.MapWidth y GC.MapHeight estén definidos correctamente
        return x >= 0 && x < GC.MapWidth && y >= 0 && y < GC.MapHeight;
    }

    public static bool CheckCellInUse(Vector2 pos){
        bool cellInUse = false;
        int posX = Mathf.FloorToInt(pos.x);
        int posY = Mathf.FloorToInt(pos.y);
        
        if (IsInsideBounds(posX, posY + 1)){
            cellInUse = GC.MapPositions[Mathf.FloorToInt(pos.x), Mathf.FloorToInt(pos.y)].IsUsed;
        }

        return cellInUse;
    }

    public static bool CheckIsEnemy(Vector2Int pos, string side){
        CellTracker ct = GC.MapPositions[Mathf.FloorToInt(pos.x), Mathf.FloorToInt(pos.y)];
        if (side != ct.Side) return true;
        return false;
    }
}