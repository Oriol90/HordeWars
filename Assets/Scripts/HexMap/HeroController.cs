using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HeroController : MonoBehaviour {
    public float moveSpeed = 3f; // Velocidad de movimiento
    private static Queue<Vector3> path = new Queue<Vector3>();
    public Tilemap tilemap;
    public static Vector3Int unitPos;
    private Animator animator; // si tienes animaciones
    protected Vector3Int heroPos;
    Vector3Int lastHeroPos;
    FogManager fogManager = new FogManager();
    

    private void Start()
    {
        transform.position = tilemap.GetCellCenterWorld(GameSaveManager.LoadHeroPos());
        lastHeroPos = GameSaveManager.LoadHeroPos();
        unitPos = Utils.WorldToCell(transform.position, tilemap);
        animator = GetComponent<Animator>();
    }

    private void Update() {
        if (path.Count > 0)
        {
            MoveAlongPath();
        }
    }

    public static void SetPath(List<Vector3Int> newPath, Tilemap tilemap) {
        path.Clear();

        foreach (var pos in newPath) {
            // Convertimos el Vector3Int (posición del tile) a mundo
            path.Enqueue(tilemap.CellToWorld(pos)); 
        }
    }

    private void MoveAlongPath()
    {
        Vector3 target = path.Peek(); // siguiente posición
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);


        // Si llegamos al tile, lo quitamos de la cola
        if (Vector3.Distance(transform.position, target) < 0.01f)
        {
            path.Dequeue();
        }

        // Animaciones opcionales
        if (animator != null)
        {
            //animator.SetBool("isWalking", path.Count > 0);
        }
        if (heroPos != Utils.WorldToCell(transform.position, tilemap))
        {
            heroPos = Utils.WorldToCell(transform.position, tilemap);
            if (lastHeroPos != heroPos) GameSaveManager.SaveHeroPos(heroPos);
            lastHeroPos = heroPos;
        }
        
    }
}