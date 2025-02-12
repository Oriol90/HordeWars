using System.Collections.Generic;
using UnityEngine;

public class UnitGenerator : MonoBehaviour
{
    private Dictionary<string, float> timers;

    private void Start(){
        InitTimers();
    }

    private void Update(){

        if(GC.TIME_INTERVAL_GIRL_KNIGHT != 0) UpdateArmy(GC.UNIT_GIRL_KNIGHT, GC.TIME_INTERVAL_GIRL_KNIGHT);
        if(GC.TIME_INTERVAL_LEAF_ARCHER != 0) UpdateArmy(GC.UNIT_LEAF_ARCHER, GC.TIME_INTERVAL_LEAF_ARCHER);

    }

    private void UpdateArmy(string unit, float timeInterval){

    timers[unit] += GC.TIME_SPEED * Time.deltaTime;
        if (timers[unit] >= timeInterval)
        {
            GC.ARMY_UNITS[unit] ++; 
            timers[unit] = 0f;
        }
    }

    private void InitTimers(){
        timers = new Dictionary<string, float>
        {
            { GC.UNIT_GIRL_KNIGHT, 0f },
            { GC.UNIT_LEAF_ARCHER, 0f }
        };
    }

}    