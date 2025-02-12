using System.Collections.Generic;
using UnityEngine;

public class UnitMovement : MonoBehaviour
{

    private Vector2Int currentGridPos;
    private Vector2Int enemyTargetGridPos;
    private int distance;
    private Vector3 destinyWorldPos;
    private Vector2Int destinyPos;
    private bool isMoving;      
    private bool hasEnemyTarget;

    void Start()
    {
        
    }

    void Update()
    {
       
    }

    public void FindClosestEnemy(string side, Vector2Int currentGridPos)
    {
        //int count = 0;
        List<KeyValuePair<Vector2Int, int>> enemies = new List<KeyValuePair<Vector2Int, int>>();
        //bool cellInUse = false;
        for (int x = 0; x < GC.MapWidth; x++) 
         {
            for (int y = 0; y < GC.MapHeight; y++)
            {
                //Debug.Log(count++);
                Vector2Int pos = new Vector2Int(x, y);
                if(BattleGroundUtils.CheckCellInUse(pos) && BattleGroundUtils.CheckIsEnemy(pos, side)){
                    {
                        distance = BattleGroundUtils.CalculateDistance(currentGridPos, pos);
                        enemies.Add(new KeyValuePair<Vector2Int, int>(pos , distance));
                    }
                }
            }
        }

        if (enemies.Count == 0)
        {
            Debug.LogWarning("No se encontraron enemigos cercanos.");
            this.hasEnemyTarget = false;
            destinyPos = currentGridPos;
        }else{
            enemies.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));
            //Si aun no tiene destinco, calcularemos la media distancia entre los enemigos.
            if(destinyPos == new Vector2Int(0, 0)){
                enemyTargetGridPos = enemies[0].Key;
                distance = enemies[0].Value;
                destinyPos = BattleGroundUtils.CalcHalfDistance(enemyTargetGridPos, currentGridPos, side);
            }else{ 
                for (int i = 0; i < enemies.Count; i++)
                {
                    if(findClosestCellNearEnemy(enemies[i])){
                        destinyPos = enemyTargetGridPos;
                        break;
                    } 
                }
            }
            this.destinyWorldPos = BattleGroundUtils.GridToWorld(destinyPos);
            this.isMoving = true;
            this.hasEnemyTarget = true;
        }
    }

    public void MoveToTarget(float velocidadMovimiento){
        
        
        //cellPainter.PaintCell(new Vector3Int(currentGridPos.x, currentGridPos.y, 0), Color.red);
        transform.position = Vector3.MoveTowards(transform.position, destinyWorldPos, velocidadMovimiento * Time.deltaTime);
        currentGridPos = BattleGroundUtils.WorldToGrid(transform.position);
        //cellPainter.PaintCell(new Vector3Int(currentGridPos.x, currentGridPos.y, 0), Color.cyan);

        // Si hemos llegado a la posición objetivo, detener el movimiento
        if (Vector3.Distance(transform.position, destinyWorldPos) < 0.01f)
        {
            isMoving = false;
            //Debug.Log("He llegado");
            //cellPainter.PaintCell(new Vector3Int(currentGridPos.x, currentGridPos.y, 0), Color.red);
        }
    }

    private bool findClosestCellNearEnemy(KeyValuePair<Vector2Int, int> enemy){
        List<KeyValuePair<Vector2Int, int>> cellsNearEnemy = new List<KeyValuePair<Vector2Int, int>>();


        int dintanceUp = BattleGroundUtils.CalculateDistance(currentGridPos, new Vector2Int(enemy.Key.x, enemy.Key.y + 1));
        int dintanceDown = BattleGroundUtils.CalculateDistance(currentGridPos, new Vector2Int(enemy.Key.x, enemy.Key.y - 1));
        int dintanceRight = BattleGroundUtils.CalculateDistance(currentGridPos, new Vector2Int(enemy.Key.x + 1, enemy.Key.y));
        int dintanceLeft = BattleGroundUtils.CalculateDistance(currentGridPos, new Vector2Int(enemy.Key.x - 1, enemy.Key.y));
        Vector2Int posUp = new Vector2Int(enemy.Key.x, enemy.Key.y + 1);
        Vector2Int posDown = new Vector2Int(enemy.Key.x, enemy.Key.y - 1);
        Vector2Int posRight = new Vector2Int(enemy.Key.x + 1, enemy.Key.y);
        Vector2Int posLeft = new Vector2Int(enemy.Key.x - 1, enemy.Key.y);
        cellsNearEnemy.Add(new KeyValuePair<Vector2Int, int>(posUp, dintanceUp));
        cellsNearEnemy.Add(new KeyValuePair<Vector2Int, int>(posDown, dintanceDown));
        cellsNearEnemy.Add(new KeyValuePair<Vector2Int, int>(posRight, dintanceRight));
        cellsNearEnemy.Add(new KeyValuePair<Vector2Int, int>(posLeft, dintanceLeft));

        cellsNearEnemy.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));
        for (int i = 0; i < cellsNearEnemy.Count; i++)
        {
            if(!BattleGroundUtils.CheckCellInUse(cellsNearEnemy[i].Key)){
                enemyTargetGridPos = cellsNearEnemy[i].Key;
                distance = cellsNearEnemy[i].Value;
                return true;
            }
        }
        return false;      
    }

    public Vector2Int DestinyPos
    {
        get { return destinyPos; }
        set { destinyPos = value; }
    }

    public Vector2Int CurrentGridPos
        {
            get { return currentGridPos; }
            set { currentGridPos = value; }
        }

    public Vector3 DestinyWorldPos
    {
        get { return destinyWorldPos; }
        set { destinyWorldPos = value; }
    }

    public bool IsMoving
    {
        get { return isMoving; }
        set { isMoving = value; }
    }

    public bool HasEnemyTarget
    {
        get { return hasEnemyTarget; }
        set { hasEnemyTarget = value; }
    }
}
