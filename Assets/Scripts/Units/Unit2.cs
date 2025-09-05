// using UnityEngine;
// using System.Collections.Generic;

// public class Unit2 : MonoBehaviour
// {
//     protected float velocidadMovimiento = 3f; // Velocidad de movimiento
//     public CellPainter cellPainter;
//     private Animator animator;
//     private SpriteRenderer spriteRenderer;
//     private UnitMovement unitMovement;
//     private string side;
//     private Vector2Int currentGridPos;
//     private Vector2Int destinyPos;

//     protected virtual void Start()
//     {
//         animator = GetComponent<Animator>();
//         spriteRenderer = GetComponent<SpriteRenderer>();
//         unitMovement = gameObject.AddComponent<UnitMovement>();

//         cellPainter = FindFirstObjectByType<CellPainter>();
//         if (cellPainter == null) Debug.LogError("No se encontró un CellPainter en la escena.");

//         CheckSide(); 

//         currentGridPos = BattleGroundUtils.WorldToGrid(gameObject.transform.position);
//         OcuparCelda(currentGridPos);

//     }

//     protected virtual void Update(){
//         UpdateSortingOrder();
//         if(Vector3.Distance(transform.position, unitMovement.DestinyWorldPos) < 0.5f && CheckIsNearEnemy(BattleGroundUtils.WorldToGrid(transform.position)).Key){
//             //Debug.Log("Al ataque!!");
//             //CheckOrientation(); ARREGLAR!!
//             if(currentGridPos != unitMovement.DestinyPos) DesocuparCelda(destinyPos);
//             animator.SetBool(GC.ANIM_ATTACK, true);
//             animator.SetBool(GC.ANIM_WALK, false);
//         }
//         else if (!unitMovement.IsMoving || !unitMovement.HasEnemyTarget){
//             unitMovement.FindClosestEnemy(side, currentGridPos);
//         }else{
//             animator.SetBool(GC.ANIM_ATTACK, false);
//             animator.SetBool(GC.ANIM_WALK, true);
//             DesocuparCelda(currentGridPos);
//             unitMovement.MoveToTarget(velocidadMovimiento);
//             currentGridPos = unitMovement.CurrentGridPos;
//             OcuparCelda(currentGridPos);
//         }
//     }

//     private void OcuparCelda(Vector2 pos){
//         int posX = Mathf.FloorToInt(pos.x);
//         int posY = Mathf.FloorToInt(pos.y);

//         if (BattleGroundUtils.IsInsideBounds(posX, posY + 1)){
//             GC.MapPositions[posX, posY] = new CellTracker(true, side, gameObject);
//         }
//     }

//     private void DesocuparCelda(Vector2 pos){
//         int posX = Mathf.FloorToInt(pos.x);
//         int posY = Mathf.FloorToInt(pos.y);
        
//         if (BattleGroundUtils.IsInsideBounds(posX, posY + 1)){
//             GC.MapPositions[Mathf.FloorToInt(pos.x), Mathf.FloorToInt(pos.y)] = new CellTracker(false, side, null);
//         }
//     }

//     private bool CheckOutOfMap(int y, int x){
//         if((x > 73 || x < 0) && (y > 40 || y < 0)) return true;
//         else return false;
//     }

//     private void CheckSide(){
//         if(gameObject.layer == LayerMask.NameToLayer(GC.ALLY)) side = GC.ALLY;
//         if(gameObject.layer == LayerMask.NameToLayer(GC.ENEMY)) side = GC.ENEMY;
//     }

//     public GameObject GetUnitByPos(Vector2Int pos){
//         return GC.MapPositions[Mathf.FloorToInt(pos.x), Mathf.FloorToInt(pos.y)].Unit;
//     }

//     private void UpdateSortingOrder()
//     {
//         if (spriteRenderer != null)
//         {
//             // Cambiar el orden de renderizado basado en la posición en Y
//             spriteRenderer.sortingOrder = Mathf.RoundToInt(-transform.position.y + 500);
//         }
//     }

//     private void CheckOrientation(){
//         if(side == GC.ALLY){
//             if(currentGridPos.x > destinyPos.x) spriteRenderer.flipX = true;
//         }else if(side == GC.ENEMY){
//             if(currentGridPos.x < destinyPos.x) spriteRenderer.flipX = false;
//         }
//     }

//     private KeyValuePair<bool, Vector2Int> CheckIsNearEnemy(Vector2Int pos)
//     {
//         bool enemyNear = false;
//         Vector2Int enemyPos = pos; // Inicializar con la posición actual

//         // Verificar vecinos en el orden arriba, derecha, abajo, izquierda
//         if (BattleGroundUtils.CheckCellInUse(new Vector2Int(pos.x, pos.y + 1)) && BattleGroundUtils.CheckIsEnemy(new Vector2Int(pos.x, pos.y + 1), side))
//         {
//             enemyNear = true;
//             enemyPos = new Vector2Int(pos.x, pos.y + 1);
//         }
//         else if (BattleGroundUtils.CheckCellInUse(new Vector2Int(pos.x + 1, pos.y)) && BattleGroundUtils.CheckIsEnemy(new Vector2Int(pos.x + 1, pos.y), side))
//         {
//             enemyNear = true;
//             enemyPos = new Vector2Int(pos.x + 1, pos.y);
//         }
//         else if (BattleGroundUtils.CheckCellInUse(new Vector2Int(pos.x, pos.y - 1)) && BattleGroundUtils.CheckIsEnemy(new Vector2Int(pos.x, pos.y - 1), side))
//         {
//             enemyNear = true;
//             enemyPos = new Vector2Int(pos.x, pos.y - 1);
//         }
//         else if (BattleGroundUtils.CheckCellInUse(new Vector2Int(pos.x - 1, pos.y)) && BattleGroundUtils.CheckIsEnemy(new Vector2Int(pos.x - 1, pos.y), side))
//         {
//             enemyNear = true;
//             enemyPos = new Vector2Int(pos.x - 1, pos.y);
//         }

//         // Retornar el resultado como KeyValuePair
//         return new KeyValuePair<bool, Vector2Int>(enemyNear, enemyPos);
//     }


// }