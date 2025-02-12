using UnityEngine;

public class InitSpawner : Spawner
{
    public GameObject girlKnight;
    public int numGirlKnight;

    public GameObject leafArchers;
    public int numLeafArchers;


    void Start(){
        if(girlKnight != null && numGirlKnight > 0) Spawn(girlKnight, numGirlKnight, GC.UNIT_GIRL_KNIGHT);
        if(leafArchers != null && numLeafArchers > 0) Spawn(leafArchers, numLeafArchers, GC.UNIT_LEAF_ARCHER);
    }
}
